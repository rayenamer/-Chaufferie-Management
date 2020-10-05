using Chaufferie.ChargesMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChElectriqueDto
    {
        public Guid ChElectriqueId { get; set; }
        public DateTime Date { get; set; }
        public decimal QuantiteConsomme { get; set; }
        public decimal PrixUnitaire { get; set; }
        public TypeCalcul typeCalculConsommation { get; set; }
        public decimal? quantiteEauConsommee { get; set; }
        public decimal? quantiteVapeurProduite { get; set; }

        public Guid FkSubsidiary { get; set; }
        public string Filiale { get; set; }
    }
    public class ChElectriqueDtoWithTotal
    {
        public List<ChElectriqueDto> ListChElectrique { get; set; }
        public decimal TotalCharges { get; set; }
    }
}
