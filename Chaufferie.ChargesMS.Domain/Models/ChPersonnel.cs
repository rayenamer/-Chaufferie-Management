using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChPersonnel
    {
        [Key]
        public Guid ChPersonnelId { get; set; }
        public Guid FkUser { get; set; }
        public decimal Salaire { get; set; }
        public decimal TauxOccupation { get; set; }
        public Guid FkSubsidiary { get; set; }
        public virtual Filiale Filiale { get; set; }
        public DateTime Date { get; set; }
    }
}
