using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp.Models
{
    public class TarifAirTangki
    {
        public long Id { get; set; }
        public long BiayaAir { get; set; }
        public long KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
