using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
   public  class PompeAlimentaire
    {
        public Guid ComposantId { get; set; }
        public DateTime DateAcquisition { get; set; }
        public decimal PrixAcquisition { get; set; }
        public EtatComposant Etat { get; set; }
        public Guid ChaudiereId { get; set; }
        public decimal PuissanceElectrique { get; set; }
    }
}
