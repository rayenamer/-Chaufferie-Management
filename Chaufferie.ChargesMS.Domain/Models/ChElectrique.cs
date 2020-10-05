using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChElectrique
    {
        [Key]
        public Guid ChElectriqueId { get; set; }
        public DateTime Date { get; set; }
        public decimal QuantiteConsomme { get; set; }
        public decimal PrixUnitaire { get; set; }
        public TypeCalcul typeCalculConsommation { get; set; }
        public decimal? quantiteEauConsommee { get; set; }
        public decimal? quantiteVapeurProduite { get; set; }

        public Guid FkSubsidiary { get; set; }
        public virtual Filiale Filiale { get; set; }
    }

    public enum TypeCalcul
    {
        index,
        theorique
    }
}
