using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewSube
    {
        public SUBE sube { get; set; }
        public IEnumerable<SUBE> Subeler { get; set; }
    }
}