using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChCombustible
    {
        [Key]
        public Guid ChCombustibleId { get; set; }
        public DateTime Date { get; set; }
        public decimal PCS { get; set; }
        public decimal? CoefficientDeCorrection { get; set; }
        public decimal QuantiteConsomme { get; set; }
        public decimal PrixUnitaire { get; set; }

        public Guid FkSubsidiary { get; set; }
        public virtual Filiale Filiale { get; set; }
    }
}
