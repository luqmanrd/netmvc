//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace netmvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vw_Reservasi
    {
        public int Reservasi_PK { get; set; }
        public Nullable<int> Ruangan_FK { get; set; }
        public string NamaRuangan { get; set; }
        public Nullable<int> Lantai { get; set; }
        public Nullable<int> DayaTampung { get; set; }
        public string SubjectReservasi { get; set; }
        public Nullable<System.DateTime> TanggalReservasi { get; set; }
        public Nullable<System.TimeSpan> JamMulai { get; set; }
        public Nullable<System.TimeSpan> JamSelesai { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
