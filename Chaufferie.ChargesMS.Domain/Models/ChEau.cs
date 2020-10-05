using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChEau
    {
        [Key]
        public Guid ChEauId { get; set; }
        public DateTime Date { get; set; }
        public decimal QuantiteConsomme { get; set; }
        public decimal PrixUnitaire { get; set; }
        public bool PrixUnitaireOsmose { get; set; }

        public Guid FkSubsidiary { get; set; }
        public virtual Filiale Filiale { get; set; }
    }
}
