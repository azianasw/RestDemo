using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp.ViewModels
{
    public class TATViewmModel : ViewModelBase
    {
        public long Id { get; set; }
        public string KategoriTarif { get; set; }
        public string NamaTarif { get; set; }
        public long BiayaAir { get; set; }
    }
}
