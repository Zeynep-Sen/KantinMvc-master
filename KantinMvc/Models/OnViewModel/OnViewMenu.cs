using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewMenu
    {
        public MENUTANIM menuTanim { get; set; }
        public IEnumerable<MENUTANIM> Menuler { get; set; }
    }
}