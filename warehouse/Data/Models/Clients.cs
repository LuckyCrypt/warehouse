using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse.Data.Models
{
    public class Clients : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
