using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class Nhanvien
{
    public string Manv { get; set; } = null!;

    public string? Tennv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public bool? Phai { get; set; }

    public string? Diachi { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; } = new List<Phieugiaohang>();
}
