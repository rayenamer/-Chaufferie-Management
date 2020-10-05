using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class UserDto
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public Guid FK_Subsidiary { get; set; }
    }
}
