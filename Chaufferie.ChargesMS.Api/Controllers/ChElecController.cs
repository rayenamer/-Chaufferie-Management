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
    public class ChElecController : ControllerBase
    {
        private readonly IGenericRepository<ChElectrique> repository;
        private readonly IMapper mapper;
        private readonly FicheSuiviRepository ficheSuiviRepository;
        private readonly ChaudiereRepository chaudiereRepository;

        #region Constructor
        public ChElecController(IGenericRepository<ChElectrique> repository, IMapper mapper, FicheSuiviRepository ficheSuiviRepository, ChaudiereRepository chaudiereRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.chaudiereRepository = chaudiereRepository;
            this.ficheSuiviRepository = ficheSuiviRepository;

        }
        #endregion

        #region Read Function
        // GET: api/ChElectrique
        [HttpGet("GetListChElectrique")]
        public async Task<IEnumerable<ChElectrique>> GetListChElectrique() =>
             await (new GetListGenericHandler<ChElectrique>(repository)).Handle(new GetListGenericQuery<ChElectrique>(condition: null, includes: x => x.Include(a => a.Filiale)), new CancellationToken());

        // GET: api/ChElectrique/5
        [HttpGet("GetChElectrique")]
        public async Task<ChElectrique> GetChElectrique(Guid id) =>
            await (new GetGenericHandler<ChElectrique>(repository)).Handle(new GetGenericQuery<ChElectrique>(condition: x => x.ChElectriqueId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/ChElectrique
        [HttpPost("PostChElectrique")]
        public async Task<ChElectrique> PostChElectrique([FromBody] ChElectrique ChElectrique)
        {

            if (ChElectrique.typeCalculConsommation.Equals(TypeCalcul.index))
            {
                var date = ChElectrique.Date.ToString("yyyy-MM-dd");
                var consommation = await ficheSuiviRepository.GetSumConsommationElectricite(ChElectrique.FkSubsidiary, date);
                ChElectrique.QuantiteConsomme = (decimal)consommation;
            }
            else if (ChElectrique.typeCalculConsommation.Equals(TypeCalcul.theorique))
            {
                var date = ChElectrique.Date.ToString("yyyy-MM-dd");
                var consommationEau = await ficheSuiviRepository.GetSumConsommationEau(ChElectrique.FkSubsidiary, date);
                var productionVapeur = await ficheSuiviRepository.GetSumConsommationVapeur(ChElectrique.FkSubsidiary, date);
                var Chaudiere = (await chaudiereRepository.GetChaudiereDtoForGet(ChElectrique.FkSubsidiary)).Where(x => x.Type.Equals(ChaudiereType.Principale)).LastOrDefault();
                if (Chaudiere != null)
                {
                    var Bruleur = (await chaudiereRepository.GetBruleurByChaudiereId(Chaudiere.ChaudiereId)).Where(x => x.Etat.Equals(EtatComposant.Marche)).LastOrDefault();
                    var PompeAlimentaire = (await chaudiereRepository.GetPompeAlimentaireByChaudiereId(Chaudiere.ChaudiereId)).Where(x => x.Etat.Equals(EtatComposant.Marche)).LastOrDefault();
                    var quantiteConsommeParPompeAlimentaire = consommationEau * PompeAlimentaire.PuissanceElectrique / PompeAlimentaire.Debit;
                    var quantiteConsommeParBruleur = productionVapeur * Bruleur.PuissanceElectrique / Chaudiere.Capacite;

                    ChElectrique.QuantiteConsomme = (decimal)quantiteConsommeParPompeAlimentaire + (decimal)quantiteConsommeParBruleur;
                }
            }
            var command = new AddGenericCommand<ChElectrique>(ChElectrique);
            var handler = new AddGenericHandler<ChElectrique>(repository);
            return await handler.Handle(command, new CancellationToken());

        }
        #endregion

        #region Update Funtion
        // PUT: api/ChElectrique/5
        [HttpPut("PutChElectrique")]
        public async Task<ChElectrique> PutChElectrique([FromBody] ChElectrique ChElectrique)
        {
            if (ChElectrique.typeCalculConsommation.Equals(TypeCalcul.index))
            {
                var date = ChElectrique.Date.ToString("yyyy-MM-dd");
                var consommation = await ficheSuiviRepository.GetSumConsommationElectricite(ChElectrique.FkSubsidiary, date);
                ChElectrique.QuantiteConsomme = (decimal)consommation;
            }
            else if (ChElectrique.typeCalculConsommation.Equals(TypeCalcul.theorique))
            {
                var date = ChElectrique.Date.ToString("yyyy-MM-dd");
                var consommationEau = await ficheSuiviRepository.GetSumConsommationEau(ChElectrique.FkSubsidiary, date);
                var productionVapeur = await ficheSuiviRepository.GetSumConsommationVapeur(ChElectrique.FkSubsidiary, date);
                var Chaudiere = (await chaudiereRepository.GetChaudiereDtoForGet(ChElectrique.FkSubsidiary)).Where(x => x.Type.Equals(ChaudiereType.Principale)).LastOrDefault();
                if (Chaudiere != null)
                {
                    var Bruleur = (await chaudiereRepository.GetBruleurByChaudiereId(Chaudiere.ChaudiereId)).Where(x => x.Etat.Equals(EtatComposant.Marche)).LastOrDefault();
                    var PompeAlimentaire = (await chaudiereRepository.GetPompeAlimentaireByChaudiereId(Chaudiere.ChaudiereId)).Where(x => x.Etat.Equals(EtatComposant.Marche)).LastOrDefault();
                    //var Adoucisseur = (await chaudiereRepository.GetAdoucisseurList(ChElectrique.FkSubsidiary)).Where(x => x.Etat.Equals(EtatComposant.Marche)).LastOrDefault();
                    var quantiteConsommeParPompeAlimentaire = consommationEau * PompeAlimentaire.PuissanceElectrique / PompeAlimentaire.Debit;
                    var quantiteConsommeParBruleur = productionVapeur * Bruleur.PuissanceElectrique / Chaudiere.Capacite;

                    ChElectrique.QuantiteConsomme = (decimal)quantiteConsommeParPompeAlimentaire + (decimal)quantiteConsommeParBruleur;
                }
            }
            var command = new PutGenericCommand<ChElectrique>(ChElectrique);
            var handler = new PutGenericHandler<ChElectrique>(repository);
            return await handler.Handle(command, new CancellationToken());
        }
        #endregion

        #region Remove Function
        // DELETE: api/ChElectrique/5
        [HttpDelete("DeleteChElectrique")]
        public async Task<ChElectrique> DeleteChElectrique(Guid id) =>
           await (new RemoveGenericHandler<ChElectrique>(repository)).Handle(new RemoveGenericCommand<ChElectrique>(id), new CancellationToken());
        #endregion

        [HttpGet("GetListChElectriqueByMonthSubsidiary")]
        public async Task<ChElectriqueDtoWithTotal> GetListChElectriqueByMonthSubsidiary(string date, Guid FkSubsidiary)
        {
            string mois;
            string annee = date.Remove(4);
            int index = date.IndexOf('0', 5);
            if (index == 5)
            {
                mois = date.Remove(0, 6);
            }
            else mois = date.Remove(0, 5);

            IEnumerable<ChElectriqueDto> ListChElectrique = (await (new GetListGenericHandler<ChElectrique>(repository)).Handle(new GetListGenericQuery<ChElectrique>(
                condition: x => x.Date.Year.ToString() == annee && x.Date.Month.ToString() == mois && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale)), new CancellationToken())).Select(data => mapper.Map<ChElectriqueDto>(data));
            ChElectriqueDtoWithTotal ChElectriqueDtoWithTotal = new ChElectriqueDtoWithTotal();
            ChElectriqueDtoWithTotal.TotalCharges = 0;
            ChElectriqueDtoWithTotal.ListChElectrique = new List<ChElectriqueDto>();
            foreach (ChElectriqueDto ChElectrique in ListChElectrique)
            {
                ChElectriqueDtoWithTotal.TotalCharges += (ChElectrique.PrixUnitaire * ChElectrique.QuantiteConsomme);
                ChElectriqueDtoWithTotal.ListChElectrique.Add(ChElectrique);
            }

            return ChElectriqueDtoWithTotal;


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


        [HttpGet("UpdateListChElectriqueByMonthSubsidiary")]
        public async Task<IEnumerable<ChElectrique>> UpdateListChElectriqueByMonthSubsidiary(DateTime date, Guid FkSubsidiary)
        {

            IEnumerable<ChElectrique> ListChElectrique = (await (new GetListGenericHandler<ChElectrique>(repository)).Handle(new GetListGenericQuery<ChElectrique>(
                condition: x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale)), new CancellationToken()));
            foreach (var item in ListChElectrique)
            {
                await this.PutChElectrique(item);
            }

            return ListChElectrique;


        }
    }
}
