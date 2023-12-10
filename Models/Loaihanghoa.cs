using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class Loaihanghoa
{
    public string Maloai { get; set; } = null!;

    public string? Tenloai { get; set; }

    public virtual ICollection<Hanghoa> Hanghoas { get; set; } = new List<Hanghoa>();
}
