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
    public class ChAssistExterneController : ControllerBase
    {
        private readonly IGenericRepository<ChAssistExterne> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ChAssistExterneController(IGenericRepository<ChAssistExterne> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        #endregion

        #region Read Function
        [HttpGet("GetListChAssistExterne")]
        public async Task<IEnumerable<ChAssistExterne>> GetListChAssistExterne() =>
             await (new GetListGenericHandler<ChAssistExterne>(repository)).Handle(new GetListGenericQuery<ChAssistExterne>(condition: null,includes: null), new CancellationToken());
                


        [HttpGet("GetChAssistExterne")]
        public async Task<ChAssistExterne> GetChAssistExterne(Guid id) =>
            await (new GetGenericHandler<ChAssistExterne>(repository)).Handle(new GetGenericQuery<ChAssistExterne>(condition: x => x.ChAssistExterneId.Equals(id), null), new CancellationToken());


        [HttpGet("GetListChAssistExterneByMonthSubsidiary")]
        public async Task<ChAssistExterneDtoForReadWithTotal> GetListChAssistExterneByMonthSubsidiary(string date,Guid FkSubsidiary)
        {
            string mois;
            string annee = date.Remove(4);
            int index = date.IndexOf('0', 5);
            if (index == 5)
            {
                mois = date.Remove(0, 6);
            }
            else mois = date.Remove(0, 5);

            IEnumerable<ChAssistExterneDtoForRead> ListChAssistExterne = (await (new GetListGenericHandler<ChAssistExterne>(repository)).Handle(new GetListGenericQuery<ChAssistExterne>(
                condition: x => x.Date.Year.ToString() == annee && x.Date.Month.ToString() == mois && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale).Include(x => x.BureauControle)), new CancellationToken())).Select(data => mapper.Map<ChAssistExterneDtoForRead>(data));
            ChAssistExterneDtoForReadWithTotal chAssistExterneDtoForReadWithTotal = new ChAssistExterneDtoForReadWithTotal();
            chAssistExterneDtoForReadWithTotal.TotalCharges = 0;
            chAssistExterneDtoForReadWithTotal.ListChAssistExterne = new List<ChAssistExterneDtoForRead>();
            foreach (ChAssistExterneDtoForRead  chAssistExterne in ListChAssistExterne)
            {
                    chAssistExterneDtoForReadWithTotal.TotalCharges += chAssistExterne.Montant;
                    chAssistExterneDtoForReadWithTotal.ListChAssistExterne.Add(chAssistExterne);
            }

            return chAssistExterneDtoForReadWithTotal;


        }
        
        [HttpGet("Date")]
        public string GetDate()
        {
            string mois = DateTime.Now.Month.ToString();
            if (mois.Length == 1)
            {
                mois = "0" + mois;
            }
            int annee = DateTime.Now.Year;
            return annee + "-" + mois;
        }
        #endregion    

        #region Add Function
        [HttpPost("PostChAssistExterne")]
        public async Task<ChAssistExterne> PostChAssistExeterne([FromBody] ChAssistExterne chAssistExeterne) =>
            await (new AddGenericHandler<ChAssistExterne>(repository)).Handle(new AddGenericCommand<ChAssistExterne>(chAssistExeterne), new CancellationToken());
        #endregion

        #region Update Funtion
        [HttpPut("PutChAssistExterne")]
        public async Task<ChAssistExterne> PutChAssistExterne([FromBody] ChAssistExterne chAssistExeterne) =>
           await (new PutGenericHandler<ChAssistExterne>(repository)).Handle(new PutGenericCommand<ChAssistExterne>(chAssistExeterne), new CancellationToken());
        #endregion

        #region Remove Function
        [HttpDelete("DeleteChAssistExterne")]
        public async Task<ChAssistExterne> DeleteChAssistExterne(Guid id) =>
           await (new RemoveGenericHandler<ChAssistExterne>(repository)).Handle(new RemoveGenericCommand<ChAssistExterne>(id), new CancellationToken());
        #endregion
    }
}