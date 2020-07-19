using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewSinif
    {
        public SINIF sinif { get; set; }
        public IEnumerable<SINIF> Siniflar { get; set; }
    }
}