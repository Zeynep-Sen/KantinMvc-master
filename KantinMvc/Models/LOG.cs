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
    
    public partial class LOG
    {
        public int ID { get; set; }
        public int MERKEZ_ID { get; set; }
        public int SUBE_ID { get; set; }
        public int KULLANICI_ID { get; set; }
        public int ISLEMTIPI_ID { get; set; }
        public int ISLEMTABLE_ID { get; set; }
        public int KAYIT_ID { get; set; }
        public System.DateTime TARIH { get; set; }
    
        public virtual LOGISLEMTIPI LOGISLEMTIPI { get; set; }
        public virtual SUBE SUBE { get; set; }
    }
}
