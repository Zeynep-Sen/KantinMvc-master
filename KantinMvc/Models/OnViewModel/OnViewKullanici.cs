using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewKullanici
    {
        public KULLANICILAR klc { get; set; }
        public IEnumerable<KULLANICILAR> Kullanicilar { get; set; }
        public IEnumerable<SUBE> Subeler { get; set; }
        public IEnumerable<KULLANICITIPI> KullaniciTip { get; set; }
     
    }
}