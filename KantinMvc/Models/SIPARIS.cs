//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KantinMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SIPARIS
    {
        public int ID { get; set; }
        public Nullable<int> SUBE_ID { get; set; }
        public int SICIL_ID { get; set; }
        public int SIPARISTIPI_ID { get; set; }
        public Nullable<int> ODEMETIPI_ID { get; set; }
        public System.DateTime SIPARISTARIHI { get; set; }
        public Nullable<bool> ONAY { get; set; }
        public string NOTLAR { get; set; }
        public Nullable<decimal> GENELTOPLAM { get; set; }
        public Nullable<System.DateTime> ISLEMTARIHI { get; set; }
        public Nullable<bool> SILINDI { get; set; }
    }
}
