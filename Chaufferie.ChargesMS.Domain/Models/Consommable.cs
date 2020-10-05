using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class Consommable
    {
        [Key]
        public Guid ConsommableId { get; set; }
        public string Nature { get; set; }
        public string Reference { get; set; }
        public decimal Consommation { get; set; }
        public decimal PrixUnitaire { get; set; }
        public DateTime Date { get; set; }
        public string Fournisseur { get; set; }
        public string Unite { get; set; }




        public Guid TypeConsommableId { get; set; }
        public TypeConsommable TypeConsommable { get; set; }


        public Guid FkSubsidiary { get; set; }
        public Filiale Filiale { get; set; }
    }
}
