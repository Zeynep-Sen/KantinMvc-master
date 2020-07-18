using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewMarka
    {
        public MARKA marka{ get; set; }
        public IEnumerable<MARKA> Markalar { get; set; }
    }
}