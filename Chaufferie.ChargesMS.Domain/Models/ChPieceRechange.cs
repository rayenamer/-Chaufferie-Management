using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChPieceRechange
    {
        [Key]
        public Guid ChPieceRechangeId { get; set; }
        public string Nom { get; set; }
        public int Nombre { get; set; }
        public string NomFournisseur { get; set; }
        public decimal Montant { get; set; }
        public Guid FkSubsidiary { get; set; }
        public virtual Filiale Filiale { get; set; }
        public DateTime Date { get; set; }
        //PJ
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
