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
    public class ChPieceRechangeController : ControllerBase
    {
        private readonly IGenericRepository<ChPieceRechange> repository;
        private readonly IMapper mapper;


        #region Constructor
        public ChPieceRechangeController(IGenericRepository<ChPieceRechange> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        #endregion

        #region Read Function
        [HttpGet("GetListChPieceRechange")]
        public async Task<IEnumerable<ChPieceRechangeDtoForRead>> GetListChPieceRechange() =>
             (await (new GetListGenericHandler<ChPieceRechange>(repository)).Handle(new GetListGenericQuery<ChPieceRechange>(condition: null,
                 includes: src=>src.Include(x=>x.Filiale)), new CancellationToken())).Select(data => mapper.Map<ChPieceRechangeDtoForRead>(data));


        [HttpGet("GetChPieceRechange")]
        public async Task<ChPieceRechange> GetChPieceRechange(Guid id) =>
            await (new GetGenericHandler<ChPieceRechange>(repository)).Handle(new GetGenericQuery<ChPieceRechange>(condition: x => x.ChPieceRechangeId.Equals(id), null), new CancellationToken());
        

        [HttpGet("GetListChPieceRechangeByMonthSubsidiary")]
        public async Task<ChPieceRechangeDtoForReadWithTotal> GetListChPieceRechangeByMonth(string date, Guid FkSubsidiary)
        {
            string mois;
            string annee = date.Remove(4);
            int index = date.IndexOf('0', 5);
            if (index == 5)
            {
                mois = date.Remove(0, 6);
            }
            else mois = date.Remove(0, 5);

            IEnumerable<ChPieceRechangeDtoForRead> ListChPieceRech = (await (new GetListGenericHandler<ChPieceRechange>(repository)).Handle(new GetListGenericQuery<ChPieceRechange>(
                condition: x => x.Date.Year.ToString() == annee && x.Date.Month.ToString() == mois && x.FkSubsidiary == FkSubsidiary,
                 includes: src => src.Include(x => x.Filiale)), new CancellationToken())).Select(data => mapper.Map<ChPieceRechangeDtoForRead>(data));

            ChPieceRechangeDtoForReadWithTotal chPieceRechangeDtoForReadWithTotal = new ChPieceRechangeDtoForReadWithTotal();
            chPieceRechangeDtoForReadWithTotal.TotalCharges = 0;
            chPieceRechangeDtoForReadWithTotal.ListChPieceRech = new List<ChPieceRechangeDtoForRead>();
            foreach(ChPieceRechangeDtoForRead chPieceRech in ListChPieceRech)
            {
                   
                    chPieceRechangeDtoForReadWithTotal.TotalCharges += (chPieceRech.Montant * chPieceRech.Nombre);
                chPieceRechangeDtoForReadWithTotal.ListChPieceRech.Add(chPieceRech);
            }
            return chPieceRechangeDtoForReadWithTotal;
        }

        [HttpGet("GetLastDateForCheck")]
        public DateTime GetLastDateForCheck()
        {
            return DateTime.Today;
        }
        #endregion

        #region Add Function
        [HttpPost("PostChPieceRechange")]
        public async Task<ChPieceRechange> PostChPieceRechange([FromBody] ChPieceRechange chPieceRechange) =>
            await (new AddGenericHandler<ChPieceRechange>(repository)).Handle(new AddGenericCommand<ChPieceRechange>(chPieceRechange), new CancellationToken());
        #endregion

        #region Update Funtion
        [HttpPut("PutChPieceRechange")]
        public async Task<ChPieceRechange> PutChPieceRechange([FromBody] ChPieceRechange chPieceRechange) =>
           await (new PutGenericHandler<ChPieceRechange>(repository)).Handle(new PutGenericCommand<ChPieceRechange>(chPieceRechange), new CancellationToken());
        #endregion

        #region Remove Function
        [HttpDelete("DeleteChPieceRechange")]
        public async Task<ChPieceRechange> DeleteChPieceRechange(Guid id) =>
           await (new RemoveGenericHandler<ChPieceRechange>(repository)).Handle(new RemoveGenericCommand<ChPieceRechange>(id), new CancellationToken());
        #endregion
    }
}