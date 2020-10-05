using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChPieceRechangeDtoForRead
    {
        public Guid ChPieceRechangeId { get; set; }
        public string Nom { get; set; }
        public int Nombre { get; set; }
        public string NomFournisseur { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public Guid FkSubsidiary { get; set; }
        public string SubsidiaryLabel { get; set; }
    }
}
