using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class Phieudathang
{
    public string Mapdh { get; set; } = null!;

    public DateTime? Ngaydh { get; set; }

    public DateTime? Ngaygh { get; set; }

    public string? Diachigh { get; set; }

    public string? Makh { get; set; }

    public virtual ICollection<Chitietphieudathang> Chitietphieudathangs { get; set; } = new List<Chitietphieudathang>();

    public virtual Khachhang? MakhNavigation { get; set; }

    public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; } = new List<Phieugiaohang>();
}
