using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChEauDto
    {
        public Guid ChEauId { get; set; }
        public DateTime Date { get; set; }
        public decimal QuantiteConsomme { get; set; }
        public decimal PrixUnitaire { get; set; }
        public bool PrixUnitaireOsmose { get; set; }
        public Guid FkSubsidiary { get; set; }
        public string  Filiale { get; set; }
    }
    public class ChEauDtoWithTotal
    {
        public List<ChEauDto> ListChEau { get; set; }
        public decimal TotalCharges { get; set; }
    }
}
