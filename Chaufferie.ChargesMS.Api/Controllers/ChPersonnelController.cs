using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chaufferie.ChargeMS.Data.Repository;
using Chaufferie.ChargesMS.Domain.Commands;
using Chaufferie.ChargesMS.Domain.Dtos;
using Chaufferie.ChargesMS.Domain.Handlers;
using Chaufferie.ChargesMS.Domain.Interfaces;
using Chaufferie.ChargesMS.Domain.Models;
using Chaufferie.ChargesMS.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chaufferie.ChargesMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChPersonnelController : ControllerBase
    {
        private readonly IGenericRepository<ChPersonnel> repository;
        private readonly IMapper mapper;
        private readonly UserRepostiory userRepostiory;

        #region Constructor
        public ChPersonnelController(IGenericRepository<ChPersonnel> repository, IMapper mapper, UserRepostiory userRepostiory)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userRepostiory = userRepostiory;
        }
        #endregion

        #region Read Function
        [HttpGet("GetListChPersonnel")]
        public async Task<IEnumerable<ChPersonnel>> GetListChPersonnel() =>
             (await (new GetListGenericHandler<ChPersonnel>(repository)).Handle(new GetListGenericQuery<ChPersonnel>(condition: null,
                includes: null), new CancellationToken()));


        [HttpGet("GetChPersonnel")]
        public async Task<ChPersonnel> GetChPersonnel(Guid id) =>
            await (new GetGenericHandler<ChPersonnel>(repository)).Handle(new GetGenericQuery<ChPersonnel>(condition: x => x.ChPersonnelId.Equals(id), null), new CancellationToken());

        [HttpGet("GetListChPersonnelByMonthSubsidiary")]
        public async Task<ChPersonnelDtoForReadWithTotal> GetListChPersonnelByMonthSubsidiary(DateTime date, Guid FkSubsidiary)
        {
            //string mois;
            //string annee = date.Remove(4);
            //int index = date.IndexOf('0', 5);
            //if (index == 5)
            //{
            //    mois = date.Remove(0, 6);
            //}
            //else mois = date.Remove(0, 5);

            IEnumerable<ChPersonnelDtoForRead> ListchPersonnel = (await (new GetListGenericHandler<ChPersonnel>(repository)).Handle(new GetListGenericQuery<ChPersonnel>(
                condition: x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.FkSubsidiary == FkSubsidiary,
              includes: src => src.Include(x => x.Filiale)), new CancellationToken())).Select(data => mapper.Map<ChPersonnelDtoForRead>(data));
            ChPersonnelDtoForReadWithTotal chPersonnelDtoForReadWithTotal = new ChPersonnelDtoForReadWithTotal();
            chPersonnelDtoForReadWithTotal.TotalCharges = 0;
            chPersonnelDtoForReadWithTotal.ListChPersonnel = new List<ChPersonnelDtoForRead>();
            IEnumerable<UserDto> ListUser = userRepostiory.GetListUserByMatricule(ListchPersonnel.Select(x=>x.Matricule).Distinct().ToList()).Result;
            foreach (ChPersonnelDtoForRead chPersonnel  in ListchPersonnel)
            {
                UserDto user = ListUser.Where(x => x.UserID == chPersonnel.FkUser).FirstOrDefault();
                chPersonnel.NomPersonnel = user.FullName;  
                chPersonnel.ChargeMensuelleParPers = (chPersonnel.Salaire * chPersonnel.TauxOccupation)/100;
                chPersonnelDtoForReadWithTotal.TotalCharges += chPersonnel.ChargeMensuelleParPers;
                chPersonnelDtoForReadWithTotal.ListChPersonnel.Add(chPersonnel);

            }
            return chPersonnelDtoForReadWithTotal;
        }


        [HttpGet("SynchChPersonnelByMonthSubsidiary")]
        public async Task<ChPersonnelDtoForReadWithTotal> SynchChPersonnelByMonthSubsidiary(DateTime date, Guid FkSubsidiary)
        {
            IEnumerable<ChPersonnel> ListAncienchPersonnel = (await (new GetListGenericHandler<ChPersonnel>(repository)).Handle(new GetListGenericQuery<ChPersonnel>(condition: x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.FkSubsidiary == FkSubsidiary, null), new CancellationToken()));
            if(ListAncienchPersonnel.Count() != 0)
            {
                foreach (ChPersonnel element in ListAncienchPersonnel)
                {
                    await this.DeleteChPersonnel(element.ChPersonnelId);
                }
            }
           
            DateTime LastMonth = date.AddMonths(-1);
            IEnumerable<ChPersonnel> ListNouvchPersonnel = (await (new GetListGenericHandler<ChPersonnel>(repository)).Handle(new GetListGenericQuery<ChPersonnel>(condition: x => x.Date.Year == LastMonth.Year && x.Date.Month == LastMonth.Month && x.FkSubsidiary == FkSubsidiary, null), new CancellationToken()));
            //List<ChPersonnelDtoForReadWithTotal> List;
            if (ListNouvchPersonnel.Count() != 0)
            {
                foreach(ChPersonnel element in ListNouvchPersonnel)
                {
                    element.Date = date;
                    element.ChPersonnelId = new Guid();
                    await this.PostChPersonnel(element);
                }
            }
            var List = await this.GetListChPersonnelByMonthSubsidiary(date, FkSubsidiary);
            return List;
        }

        #endregion

        #region Add Function
        [HttpPost("PostChPersonnel")]
        public async Task<ChPersonnel> PostChPersonnel([FromBody] ChPersonnel chPersonnel) =>
            await (new AddGenericHandler<ChPersonnel>(repository)).Handle(new AddGenericCommand<ChPersonnel>(chPersonnel), new CancellationToken());
        #endregion

        #region Update Funtion
        [HttpPut("PutChPersonnel")]
        public async Task<ChPersonnel> PutChPersonnel([FromBody] ChPersonnel chPersonnel) =>
           await (new PutGenericHandler<ChPersonnel>(repository)).Handle(new PutGenericCommand<ChPersonnel>(chPersonnel), new CancellationToken());
        #endregion

        #region Remove Function
        [HttpDelete("DeleteChPersonnel")]
        public async Task<ChPersonnel> DeleteChPersonnel(Guid id) =>
           await (new RemoveGenericHandler<ChPersonnel>(repository)).Handle(new RemoveGenericCommand<ChPersonnel>(id), new CancellationToken());
        #endregion
    }
}