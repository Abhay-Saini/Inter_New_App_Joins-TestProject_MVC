//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inter_New_App_Joins.DbConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Marks
    {
        public int M_Id { get; set; }
        public int Maths { get; set; }
        public int Hindi { get; set; }
        public int English { get; set; }
        public int Science { get; set; }
        public Nullable<int> Stu_Id { get; set; }
    
        public virtual tbl_Student tbl_Student { get; set; }
    }
}
