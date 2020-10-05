using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ComposantDto
    {
        public Guid ComposantId { get; set; }
        public Guid ChaudiereId { get; set; }
        public string Composant { get; set; }
        public EtatComposant Etat { get; set; }
        public DateTime DateAcquisition { get; set; }
        public decimal PrixAcquisition { get; set; }
        public int DureeAmortissement { get; set; }
        public Guid subsidiaryId { get; set; }
    }
}
