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
    using System.ComponentModel.DataAnnotations;

    public partial class TBL_PRODUCTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PRODUCTS()
        {
            this.TBL_ORDERS = new HashSet<TBL_ORDERS>();
        }
    
        public int P_ID { get; set; }
        public string P_NAME { get; set; }
        [DataType(DataType.MultilineText)]
        public string P_DISCRIPTION { get; set; }
        public string P_IMG { get; set; }
        public float P_PRICE { get; set; }
        public Nullable<int> P_STATUT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ORDERS> TBL_ORDERS { get; set; }
    }
}