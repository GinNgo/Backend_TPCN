using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebSiteBanThucPhamCN.Models
{
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double Total { get; set; }
        public string Period { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
