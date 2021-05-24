using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chaufferie.ChargeMS.Data.Repository;
using Chaufferie.ChargesMS.Domain.Dtos;
using Chaufferie.ChargesMS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chaufferie.ChargesMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChAmortissementController : ControllerBase
    {
        private readonly ChaudiereRepository chaudiereRepository;
        public ChAmortissementController(ChaudiereRepository chaudiereRepository)
        {
            this.chaudiereRepository = chaudiereRepository;
          
        }
                                                                                                                                                                                                                        
        //[HttpGet]
        //public async Task<ChAmortissement> GenerateChAmortissement(Guid subsidiaryId, DateTime date)
        //{
        //    ChAmortissement chAmortissement = new ChAmortissement();
        //    IEnumerable<ComposantDto> composants = await chaudiereRepository.GetComposantsDto(subsidiaryId, date); 
        //    IEnumerable<AccessoiresDto> accessoires = await chaudiereRepository.GetAccessoiresDto(subsidiaryId, date);
        //    decimal SommeChargesMensuelle = 0;
        //    decimal prixRevient = 0;

        //    foreach (var composant in composants)
        //    {
        //        var days = DateTime.DaysInMonth(composant.DateAcquisition.Year, composant.DateAcquisition.Month);
        //        SommeChargesMensuelle += (composant.PrixAcquisition * (decimal)0.1 * days) / 360; 
        //    }

        //    prixRevient = SommeChargesMensuelle / 20;
        //    chAmortissement.Composants = composants;
        //    chAmortissement.SommeChargesMensuelle = SommeChargesMensuelle;
        //    chAmortissement.PrixRevient = prixRevient;


        //    return chAmortissement;
        //}

        [HttpGet("GetChComposantsEtAccessoires")]
        public async Task<ChAmortissement> GetChComposantsEtAccessoires(Guid subsidiaryId, DateTime date)
        {
            var dateTime = date.ToString("yyyy-MM-dd h:mm tt");
            ChAmortissement chAmortissement = new ChAmortissement();
            IEnumerable<ComposantDto> composants = await chaudiereRepository.GetComposantsDto(subsidiaryId, dateTime);
            IEnumerable<AccessoiresDto> accessoires = await chaudiereRepository.GetAccessoiresDto(subsidiaryId, dateTime);
            decimal SommeChargesMensuelle = 0;

            foreach (var composant in composants)
            {
                SommeChargesMensuelle += (composant.PrixAcquisition / composant.DureeAmortissement);
            }
            foreach (var accessoire in accessoires)
            {
                SommeChargesMensuelle += accessoire.MontantMensuel;
            }


            chAmortissement.Composants = composants;
            chAmortissement.Accessoires = accessoires;
            chAmortissement.SommeChargesMensuelle = SommeChargesMensuelle;


            return chAmortissement;
        }

        [HttpGet("GetLastDateForCheck")]
        public DateTime GetLastDateForCheck()
        {
            return DateTime.Today;
        }

    }
}
