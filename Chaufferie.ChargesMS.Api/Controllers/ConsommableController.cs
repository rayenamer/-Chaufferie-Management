using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ConsommableController : ControllerBase
    {
        private readonly IGenericRepository<Consommable> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ConsommableController(IGenericRepository<Consommable> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Consommable
        [HttpGet("GetListConsommable")]
        public async Task<IEnumerable<Consommable>> GetListConsommable() =>
             await (new GetListGenericHandler<Consommable>(repository)).Handle(new GetListGenericQuery<Consommable>(condition: null, includes: x => x.Include(a => a.TypeConsommable).Include(a => a.Filiale)), new CancellationToken());

        // GET: api/Consommable/5
        [HttpGet("GetConsommable")]
        public async Task<Consommable> GetConsommable(Guid id) =>
            await (new GetGenericHandler<Consommable>(repository)).Handle(new GetGenericQuery<Consommable>(condition: x => x.ConsommableId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Consommable
        [HttpPost("PostConsommable")]
        public async Task<Consommable> PostConsommable([FromBody] Consommable Consommable) =>
            await (new AddGenericHandler<Consommable>(repository)).Handle(new AddGenericCommand<Consommable>(Consommable), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Consommable/5
        [HttpPut("PutConsommable")]
        public async Task<Consommable> PutConsommable([FromBody] Consommable Consommable) =>
           await (new PutGenericHandler<Consommable>(repository)).Handle(new PutGenericCommand<Consommable>(Consommable), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Consommable/5
        [HttpDelete("DeleteConsommable")]
        public async Task<Consommable> DeleteConsommable(Guid id) =>
           await (new RemoveGenericHandler<Consommable>(repository)).Handle(new RemoveGenericCommand<Consommable>(id), new CancellationToken());
        #endregion


        [HttpGet("GetListConsommableByMonthSubsidiary")]
        public async Task<ConsommableDtoWithTotal> GetListConsommableByMonthSubsidiary(string date, Guid FkSubsidiary)
        {
            string mois;
            string annee = date.Remove(4);
            int index = date.IndexOf('0', 5);
            if (index == 5)
            {
                mois = date.Remove(0, 6);
            }
            else mois = date.Remove(0, 5);

            IEnumerable<ConsommableDto> ListConsommable = (await (new GetListGenericHandler<Consommable>(repository)).Handle(new GetListGenericQuery<Consommable>(
                condition: x => x.Date.Year.ToString() == annee && x.Date.Month.ToString() == mois && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale).Include(x => x.TypeConsommable)), new CancellationToken())).Select(data => mapper.Map<ConsommableDto>(data));
            ConsommableDtoWithTotal ConsommableDtoWithTotal = new ConsommableDtoWithTotal();
            ConsommableDtoWithTotal.TotalCharges = 0;
            ConsommableDtoWithTotal.ListConsommable = new List<ConsommableDto>();
            foreach (ConsommableDto consommable in ListConsommable)
            {
                ConsommableDtoWithTotal.TotalCharges += (consommable.PrixUnitaire * consommable.Consommation);
                ConsommableDtoWithTotal.ListConsommable.Add(consommable);
            }

            return ConsommableDtoWithTotal;


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

    }
}