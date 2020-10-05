using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class AccessoiresDto
    {
        public Guid AccessoireId { get; set; }
        public string Libelle { get; set; }
        public DateTime DateAcquisition { get; set; }
        public decimal PrixAcquisition { get; set; }
        public int DureeAmortissement { get; set; }
        public decimal MontantMensuel { get; set; }
        public Guid subsidiaryId { get; set; }
        public string Filiale { get; set; }
    }
}
