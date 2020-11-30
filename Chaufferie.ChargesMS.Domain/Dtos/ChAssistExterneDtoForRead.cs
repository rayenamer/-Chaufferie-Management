using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChAssistExterneDtoForRead
    {
        public Guid ChAssistExterneId { get; set; }
        public decimal Montant { get; set; }
        public string SousTraitant { get; set; }
        public string Intervention { get; set; }
        //public Guid FkTypeIntervention { get; set; }
        //public string LibelleTypeIntervention { get; set; }
        public Guid? FkBureauControle { get; set; }
        public string LibelleBureauControle { get; set; }
        public DateTime Date { get; set; }
        public Guid FkSubsidiary { get; set; }
        public string SubsidiaryLabel { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
