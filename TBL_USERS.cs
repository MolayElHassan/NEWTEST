//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEWTEST
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USERS()
        {
            this.TBL_INVOICES = new HashSet<TBL_INVOICES>();
        }
    
        public int U_ID { get; set; }
        public string U_EMAIL { get; set; }
        public string U_PASSWORD { get; set; }
        public string U_PHONE { get; set; }
        public string U_ADRESS { get; set; }
        public Nullable<int> U_TYPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INVOICES> TBL_INVOICES { get; set; }
    }
}