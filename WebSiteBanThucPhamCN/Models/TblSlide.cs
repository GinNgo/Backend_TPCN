using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebSiteBanThucPhamCN.Models
{
    public partial class TblSlide
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
    }
}
