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
    
    public partial class TBL_ORDERS
    {
        public int O_ID { get; set; }
        public int P_ID { get; set; }
        public int I_ID { get; set; }
        public int O_QTE { get; set; }
        public Nullable<System.DateTime> O_DATE { get; set; }
    
        public virtual TBL_INVOICES TBL_INVOICES { get; set; }
        public virtual TBL_PRODUCTS TBL_PRODUCTS { get; set; }
    }
}