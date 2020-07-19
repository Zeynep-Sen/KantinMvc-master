using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinMvc.Models.OnViewModel
{
    public class OnViewCari
    {
        public CARIKART cari { get; set; }
        public IEnumerable<CARIKART> Cariler { get; set; }
    }
}