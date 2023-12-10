using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class Hanghoa
{
    public string Mahang { get; set; } = null!;

    public string? Tenhang { get; set; }

    public string? Donvitinh { get; set; }

    public double? Dongia { get; set; }

    public string? Hinh { get; set; }

    public string? Maloai { get; set; }

    public string? Mansx { get; set; }

    public virtual ICollection<Chitietphieudathang> Chitietphieudathangs { get; set; } = new List<Chitietphieudathang>();

    public virtual ICollection<Chitietphieugiaohang> Chitietphieugiaohangs { get; set; } = new List<Chitietphieugiaohang>();

    public virtual Loaihanghoa? MaloaiNavigation { get; set; }

    public virtual Nhasanxuat? MansxNavigation { get; set; }
}
