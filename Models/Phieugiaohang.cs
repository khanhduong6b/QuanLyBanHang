using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class Phieugiaohang
{
    public string Mapgh { get; set; } = null!;

    public DateTime? Ngaygh { get; set; }

    public string? Diachigh { get; set; }

    public string? Tennguoinhan { get; set; }

    public string? Mapdh { get; set; }

    public string? Manv { get; set; }

    public virtual ICollection<Chitietphieugiaohang> Chitietphieugiaohangs { get; set; } = new List<Chitietphieugiaohang>();

    public virtual Nhanvien? ManvNavigation { get; set; }

    public virtual Phieudathang? MapdhNavigation { get; set; }
}
