using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChAssistExterne
    {
        [Key]
        public Guid ChAssistExterneId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string SousTraitant { get; set; }
        public string Intervention { get; set; }
        //public Guid FkTypeIntervention { get; set; }
        //public virtual TypeIntervention TypeIntervention { get; set; }
        public Guid? FkBureauControle { get; set; }
        public virtual BureauControle BureauControle  { get; set; }
        public Guid FkSubsidiary{ get; set; }
        public virtual Filiale Filiale { get; set; }
        //PJ
        public string FilePath { get; set; }
        public string FileName { get; set; }

    }
}
