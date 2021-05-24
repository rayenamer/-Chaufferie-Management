using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ChCombustibleController : ControllerBase
    {
        private readonly IGenericRepository<ChCombustible> repository;
        private readonly IMapper mapper;
        private readonly FicheSuiviRepository ficheSuiviRepository;
        private readonly ChaudiereRepository chaudiereRepository;

        #region Constructor
        public ChCombustibleController(IGenericRepository<ChCombustible> repository, IMapper mapper, FicheSuiviRepository ficheSuiviRepository, ChaudiereRepository chaudiereRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.chaudiereRepository = chaudiereRepository;
            this.ficheSuiviRepository = ficheSuiviRepository;

        }
        #endregion

        #region Read Function
        // GET: api/ChCombustible
        [HttpGet("GetListChCombustible")]
        public async Task<IEnumerable<ChCombustible>> GetListChCombustible() =>
             await (new GetListGenericHandler<ChCombustible>(repository)).Handle(new GetListGenericQuery<ChCombustible>(condition: null, includes: x => x.Include(a => a.Filiale)), new CancellationToken());

        // GET: api/ChCombustible/5
        [HttpGet("GetChCombustible")]
        public async Task<ChCombustible> GetChCombustible(Guid id) =>
            await (new GetGenericHandler<ChCombustible>(repository)).Handle(new GetGenericQuery<ChCombustible>(condition: x => x.ChCombustibleId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/ChCombustible
        [HttpPost("PostChCombustible")]
        public async Task<ChCombustible> PostChCombustible([FromBody] ChCombustible ChCombustible)
        {
            var Chaudiere = (await chaudiereRepository.GetChaudiereDtoForGet(ChCombustible.FkSubsidiary)).Where(x => x.Type.Equals(ChaudiereType.Principale)).LastOrDefault();
            var date = ChCombustible.Date.ToString("yyyy-MM-dd");
            string type = chaudiereRepository.GetTypeChaudiereByFilialeId(ChCombustible.FkSubsidiary).Result;
            int? consommation = 0;
            switch (type)
            {
                case "Vapeur":
                    consommation = await ficheSuiviRepository.GetSumConsommationGaz(ChCombustible.FkSubsidiary, date);
                    break;
                case "Récupération":
                    consommation = await ficheSuiviRepository.GetSumConsommationGazRecuperation(ChCombustible.FkSubsidiary, date);
                    break;
            }
            if (Chaudiere.TypeCombustible.Equals(TypeCombustible.Gaz) || Chaudiere.TypeCombustible.Equals(TypeCombustible.AirChaud))
            {
                ChCombustible.QuantiteConsomme = (decimal)consommation * (decimal)ChCombustible.PCS * (decimal)ChCombustible.CoefficientDeCorrection;
            }
            else if (Chaudiere.TypeCombustible.Equals(TypeCombustible.Fuel) || Chaudiere.TypeCombustible.Equals(TypeCombustible.Gasoil))
            {
                ChCombustible.QuantiteConsomme = (decimal)consommation * (decimal)ChCombustible.PCS;
            }
            var command = new AddGenericCommand<ChCombustible>(ChCombustible);
            var handler = new AddGenericHandler<ChCombustible>(repository);
            return await handler.Handle(command, new CancellationToken());

        }
        #endregion

        #region Update Funtion
        // PUT: api/ChCombustible/5
        [HttpPut("PutChCombustible")]
        public async Task<ChCombustible> PutChCombustible([FromBody] ChCombustible ChCombustible)
        {
            var Chaudiere = (await chaudiereRepository.GetChaudiereDtoForGet(ChCombustible.FkSubsidiary)).Where(x => x.Type.Equals(ChaudiereType.Principale)).LastOrDefault();
            var date = ChCombustible.Date.ToString("yyyy-MM-dd");
            string type = chaudiereRepository.GetTypeChaudiereByFilialeId(ChCombustible.FkSubsidiary).Result;
            int? consommation = 0;
            switch (type)
            {
                case "Vapeur":
                    consommation = await ficheSuiviRepository.GetSumConsommationGaz(ChCombustible.FkSubsidiary, date);
                    break;
                case "Récupération":
                    consommation = await ficheSuiviRepository.GetSumConsommationGazRecuperation(ChCombustible.FkSubsidiary, date);
                    break;
            }
            if (Chaudiere.TypeCombustible.Equals(TypeCombustible.Gaz) || Chaudiere.TypeCombustible.Equals(TypeCombustible.AirChaud))
            {
                ChCombustible.QuantiteConsomme = (decimal)consommation * ChCombustible.PCS * (decimal)ChCombustible.CoefficientDeCorrection;
            }
            else if (Chaudiere.TypeCombustible.Equals(TypeCombustible.Fuel) || Chaudiere.TypeCombustible.Equals(TypeCombustible.Gasoil))
            {
                ChCombustible.QuantiteConsomme = (decimal)consommation * ChCombustible.PCS;
            }
            var command = new PutGenericCommand<ChCombustible>(ChCombustible);
            var handler = new PutGenericHandler<ChCombustible>(repository);
            return await handler.Handle(command, new CancellationToken());
        }
        #endregion

        #region Remove Function
        // DELETE: api/ChCombustible/5
        [HttpDelete("DeleteChCombustible")]
        public async Task<ChCombustible> DeleteChCombustible(Guid id) =>
           await (new RemoveGenericHandler<ChCombustible>(repository)).Handle(new RemoveGenericCommand<ChCombustible>(id), new CancellationToken());
        #endregion

        [HttpGet("GetListChCombustibleByMonthSubsidiary")]
        public async Task<ChCombustibleDtoWithTotal> GetListChCombustibleByMonthSubsidiary(string date, Guid FkSubsidiary)
        {
            string mois;
            string annee = date.Remove(4);
            int index = date.IndexOf('0', 5);
            if (index == 5)
            {
                mois = date.Remove(0, 6);
            }
            else mois = date.Remove(0, 5);

            IEnumerable<ChCombustibleDto> ListChCombustible = (await (new GetListGenericHandler<ChCombustible>(repository)).Handle(new GetListGenericQuery<ChCombustible>(
                condition: x => x.Date.Year.ToString() == annee && x.Date.Month.ToString() == mois && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale)), new CancellationToken())).Select(data => mapper.Map<ChCombustibleDto>(data));
            ChCombustibleDtoWithTotal ChCombustibleDtoWithTotal = new ChCombustibleDtoWithTotal();
            ChCombustibleDtoWithTotal.TotalCharges = 0;
            ChCombustibleDtoWithTotal.ListChCombustible = new List<ChCombustibleDto>();
            foreach (ChCombustibleDto ChCombustible in ListChCombustible)
            {
                ChCombustibleDtoWithTotal.TotalCharges += (ChCombustible.PrixUnitaire * ChCombustible.QuantiteConsomme);
                ChCombustibleDtoWithTotal.ListChCombustible.Add(ChCombustible);
            }

            return ChCombustibleDtoWithTotal;


        }

        [HttpGet("GetLastDateForCheck")]
        public DateTime GetLastDateForCheck()
        {
            return DateTime.Today;
        }

        [HttpGet("CheckTypeCombustible")]
        public async Task<TypeCombustible> CheckTypeCombustible(Guid FilialeId)
        {




            try
            {
                var Chaudiere = (await chaudiereRepository.GetChaudiereDtoForGet(FilialeId)).Where(x => x.Type.Equals(ChaudiereType.Principale)).LastOrDefault();

                return Chaudiere.TypeCombustible;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpGet("UpdateListChCombustibleByMonthSubsidiary")]
        public async Task<IEnumerable<ChCombustible>> UpdateListChCombustibleByMonthSubsidiary(DateTime date, Guid FkSubsidiary)
        {


            IEnumerable<ChCombustible> ListChCombustible = (await (new GetListGenericHandler<ChCombustible>(repository)).Handle(new GetListGenericQuery<ChCombustible>(
                condition: x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale)), new CancellationToken()));
            foreach (var item in ListChCombustible)
            {
                await this.PutChCombustible(item);
            }

            return ListChCombustible;


        }
    }
}
