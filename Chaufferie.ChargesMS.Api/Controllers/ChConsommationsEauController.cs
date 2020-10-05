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
    public class ChConsommationsEauController : ControllerBase
    {
        private readonly IGenericRepository<ChEau> repository;
        private readonly FicheSuiviRepository ficheSuiviRepository;
        private readonly ChaudiereRepository chaudiereRepository;
        private readonly IMapper mapper;

        #region Constructor
        public ChConsommationsEauController(IGenericRepository<ChEau> repository, FicheSuiviRepository ficheSuiviRepository, ChaudiereRepository chaudiereRepository, IMapper mapper)
        {
            this.repository = repository;
            this.ficheSuiviRepository = ficheSuiviRepository;
            this.chaudiereRepository = chaudiereRepository;
            this.mapper = mapper;
        }
        #endregion
        
        #region Read Function
        // GET: api/ChEau
        [HttpGet("GetListChEau")]
        public async Task<IEnumerable<ChEau>> GetListChEau() =>
             await (new GetListGenericHandler<ChEau>(repository)).Handle(new GetListGenericQuery<ChEau>(condition: null, includes: null), new CancellationToken());

        // GET: api/ChEau/5
        [HttpGet("GetChEau")]
        public async Task<ChEau> GetChEau(Guid id) =>
            await (new GetGenericHandler<ChEau>(repository)).Handle(new GetGenericQuery<ChEau>(condition: x => x.ChEauId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/ChEau
        [HttpPost("PostChEau")]
        public async Task<ChEau> PostChEau([FromBody] ChEau chEau)
        {
            // var adoucisseur = await chaudiereRepository.GetAdoucisseur(chEau.FkSubsidiary);
            // IEnumerable<FSVapeurDto> FsVapeurList = await ficheSuiviRepository.GetListFSVapeur(chEau.FkSubsidiary);

            //var BesoinEnEAUAdouc = FsVapeurList.Where(x => x.Type_Prin_Sec.Equals(ChaudiereType.Principale)).FirstOrDefault().Capacite * chEau.NbreHeureTravail;
            //var VolumeResine = adoucisseur.VolumeResine;
            //var THentree = FsVapeurList.Select(x => x.THe_Eau_Adoucie).Average();
            //var Cycle = (VolumeResine * 5) / THentree;
            //var CadenceRegeneration = BesoinEnEAUAdouc / Cycle;
            //var SelConsomme = (decimal)0.13 * VolumeResine;
            //var SelTotalRegeneration = SelConsomme * CadenceRegeneration;
            //var VolumeTotalEauRejet = chEau.VolumeEau * CadenceRegeneration;
            //var CoutSel = SelTotalRegeneration * chEau.PrixUnitaireSel;
            //var CoutEau = BesoinEnEAUAdouc * chEau.PrixUnitaireEau;
            //var CoutTotal = CoutSel + CoutEau;
            //var CoutEauAdoucie = CoutTotal / (BesoinEnEAUAdouc - VolumeTotalEauRejet);
            var date = chEau.Date.ToString("yyyy-MM-dd");
            var consommation = await ficheSuiviRepository.GetSumConsommationEau(chEau.FkSubsidiary, date);
            chEau.QuantiteConsomme = (decimal)consommation;
            if (chEau.PrixUnitaireOsmose == true)
            {
                var year = date.Substring(0, 4);
                var month = date.Substring(5, 2);
                var prix = (await chaudiereRepository.GetPrixOsmose(month, year)).price;
                chEau.PrixUnitaire = prix;
            }
 
            
            //DateTime MinDate = new DateTime(chEau.Date.Year, chEau.Date.Month, 1);
            //int days = DateTime.DaysInMonth(chEau.Date.Year, chEau.Date.Month);
            //DateTime MaxDate = MinDate.AddDays(days);
            //int i = 0;
            //do
            //{
            //    var datemax = MaxDate.AddDays(-i);
            //    var datemin = datemax.AddDays(-1);
            //    var s = FsVapeurList.Where(x => x.DateSaisie.Equals(datemax)).FirstOrDefault();
            //    var d = FsVapeurList.Where(x => x.DateSaisie.Equals(datemin)).FirstOrDefault();
            //    if ((s!=null)&&(d!=null))
            //    {
            //        chEau.QuantiteConsomme += (decimal)s.IndexEauAdoucie - (decimal)d.IndexEauAdoucie;

            //    }
            //    i++;
            //} while (i < days);
       
         
            var command = new AddGenericCommand<ChEau>(chEau);
            var handler = new AddGenericHandler<ChEau>(repository);
            return await handler.Handle(command, new CancellationToken());

        }
           
        #endregion








        #region Update Funtion
        // PUT: api/ChEau/5
        [HttpPut("PutChEau")]
        public async Task<ChEau> PutChEau([FromBody] ChEau ChEau)
        {
            var date = ChEau.Date.ToString("yyyy-MM-dd");
            var consommation = await ficheSuiviRepository.GetSumConsommationEau(ChEau.FkSubsidiary, date);
            ChEau.QuantiteConsomme = (decimal)consommation;
            if (ChEau.PrixUnitaireOsmose == true)
            {
                ChEau.PrixUnitaire = 10;
            }

            var command = new PutGenericCommand<ChEau>(ChEau);
            var handler = new PutGenericHandler<ChEau>(repository);
            return await handler.Handle(command, new CancellationToken());
        }
        #endregion

        #region Remove Function
        // DELETE: api/ChEau/5
        [HttpDelete("DeleteChEau")]
        public async Task<ChEau> DeleteChEau(Guid id) =>
           await (new RemoveGenericHandler<ChEau>(repository)).Handle(new RemoveGenericCommand<ChEau>(id), new CancellationToken());
        #endregion


        [HttpGet("GetListChEauByMonthSubsidiary")]
        public async Task<ChEauDtoWithTotal> GetListChEauByMonthSubsidiary(string date, Guid FkSubsidiary)
        {
            string mois;
            string annee = date.Remove(4);
            int index = date.IndexOf('0', 5);
            if (index == 5)
            {
                mois = date.Remove(0, 6);
            }
            else mois = date.Remove(0, 5);

            IEnumerable<ChEauDto> ListChEau = (await (new GetListGenericHandler<ChEau>(repository)).Handle(new GetListGenericQuery<ChEau>(
                condition: x => x.Date.Year.ToString() == annee && x.Date.Month.ToString() == mois && x.FkSubsidiary == FkSubsidiary,
               includes: src => src.Include(x => x.Filiale)), new CancellationToken())).Select(data => mapper.Map<ChEauDto>(data));
            ChEauDtoWithTotal ChEauDtoWithTotal = new ChEauDtoWithTotal();
            ChEauDtoWithTotal.TotalCharges = 0;
            ChEauDtoWithTotal.ListChEau = new List<ChEauDto>();
            foreach (ChEauDto ChEau in ListChEau)
            {
                ChEauDtoWithTotal.TotalCharges += (ChEau.PrixUnitaire * ChEau.QuantiteConsomme);
                ChEauDtoWithTotal.ListChEau.Add(ChEau);
            }

            return ChEauDtoWithTotal;


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