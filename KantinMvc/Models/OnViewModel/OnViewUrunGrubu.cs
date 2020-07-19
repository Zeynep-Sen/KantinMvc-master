using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewUrunGrubu
    {
        public URUNGRUBU urunGrubu { get; set; }
        public IEnumerable<URUNGRUBU> UrunGruplar{ get; set; }
    }
}