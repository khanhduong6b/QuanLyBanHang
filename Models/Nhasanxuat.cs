using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class Nhasanxuat
{
    public string? Mansx { get; set; }

    public string? Tennsx { get; set; }

    public string? Diachi { get; set; }

    public virtual ICollection<Hanghoa> Hanghoas { get; set; } = new List<Hanghoa>();
}
