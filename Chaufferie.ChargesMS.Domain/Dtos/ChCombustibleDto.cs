using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
 
        public class ChCombustibleDto
        {
        public Guid ChCombustibleId { get; set; }
        public DateTime Date { get; set; }
        public decimal PCS { get; set; }
        public decimal? CoefficientDeCorrection { get; set; }
        public decimal QuantiteConsomme { get; set; }
        public decimal PrixUnitaire { get; set; }
        public Guid FkSubsidiary { get; set; }
            public string Filiale { get; set; }
        }
        public class ChCombustibleDtoWithTotal
    {
            public List<ChCombustibleDto> ListChCombustible { get; set; }
            public decimal TotalCharges { get; set; }
        }
    
}
