using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChPieceRechangeDtoForReadWithTotal
    {
        public List<ChPieceRechangeDtoForRead> ListChPieceRech { get; set; }
        public decimal TotalCharges { get; set; }
    }
}
