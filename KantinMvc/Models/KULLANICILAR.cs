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
    
    public partial class KULLANICILAR
    {
        public int ID { get; set; }
        public Nullable<int> SUBE_ID { get; set; }
        public Nullable<int> KULLANICITIPI_ID { get; set; }
        public string KULLANICIADI { get; set; }
        public string SIFRE { get; set; }
        public Nullable<bool> AKTIF { get; set; }
        public Nullable<bool> SILINDI { get; set; }
    }
}
