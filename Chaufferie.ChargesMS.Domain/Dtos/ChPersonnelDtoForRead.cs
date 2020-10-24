using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChPersonnelDtoForRead
    {
        public Guid ChPersonnelId { get; set; }
        public Guid FkUser { get; set; }
        public string NomPersonnel { get; set; }
        public decimal Salaire { get; set; }
        public decimal TauxOccupation { get; set; }
        public Guid FkSubsidiary { get; set; }
        public string SubsidiaryLabel { get; set; }
        public decimal ChargeMensuelleParPers { get; set; }
        public DateTime Date { get; set; }
        public string Matricule { get; set; }
    }
}
