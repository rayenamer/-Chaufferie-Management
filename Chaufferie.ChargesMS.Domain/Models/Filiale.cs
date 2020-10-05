using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class Filiale
    {
        [Key]
        public Guid subsidiaryId { get; set; }
        public string label { get; set; }
        public string subsidiaryCode { get; set; }
        public byte? logo { get; set; }
        public UniteC? UniteCombustible { get; set; }

        public Guid? UniteId { get; set; }

        public Guid? SecteurId { get; set; }

        public virtual ICollection<ChPersonnel> ChPersonnels { get; set; }
        public virtual ICollection<ChAssistExterne> ChAssistExeternes { get; set; }
        public virtual ICollection<ChPieceRechange> ChPieceRechanges { get; set; }
        public virtual ICollection<Consommable> Consommables { get; set; }
        public virtual ICollection<ChEau> ChConsommationsEau { get; set; }
        public virtual ICollection<ChCombustible> ChCombustibles { get; set; }
        public virtual ICollection<ChElectrique> ChElectriques { get; set; }


        public enum UniteC
        {
            m3,
            tonne,
            litre
        }

    }

}
