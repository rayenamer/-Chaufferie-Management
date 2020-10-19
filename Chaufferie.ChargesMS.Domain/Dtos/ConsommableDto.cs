using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ConsommableDto
    {
        public Guid ConsommableId { get; set; }
        public string Nature { get; set; }
        public string Reference { get; set; }
        public decimal Consommation { get; set; }
        public decimal PrixUnitaire { get; set; }
        public DateTime Date { get; set; }
        public Guid TypeConsommableId { get; set; }
        public string TypeConsommable { get; set; }
        public Guid FournisseurId { get; set; }
        public string Fournisseur { get; set; }
        public Guid FkSubsidiary { get; set; }
        public string Filiale { get; set; }
        public string Unite { get; set; }
    }



    public class ConsommableDtoWithTotal
    {
        public List<ConsommableDto> ListConsommable { get; set; }
        public decimal TotalCharges { get; set; }
         public decimal TotalChargesProduitsChimiques { get; set; }
    }
}
