using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestDemo.Models
{
    public class TarifAirTangki
    {
        public long Id { get; set; }
        public long BiayaAir { get; set; }
        public long KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
