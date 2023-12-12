using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models;

public partial class Hanghoa
{

    [Required(ErrorMessage = "Xin nhập mã hàng hóa ")]// rang buoc nhap dl
    [Display(Name = "Mã hàng hóa")]
    public string Mahang { get; set; } = null!;
    [Required(ErrorMessage = "Xin nhập tên hàng hóa ")]// rang buoc nhap dl
    [Display(Name = "Tên hàng hóa")]
    public string? Tenhang { get; set; }
    [Required(ErrorMessage = "Xin nhập đơn vị tính ")]// rang buoc nhap dl
    [Display(Name = "Đơn vị tính")]
    public string? Donvitinh { get; set; }
    [Required(ErrorMessage = "Xin nhập đơn giá ")]// rang buoc nhap dl
    [Display(Name = "Đơn giá")]
    public double? Dongia { get; set; }

    [Display(Name = "Hình ảnh")]
    public string? Hinh { get; set; }
    [Display(Name = "Mã loại")]
    public string? Maloai { get; set; }
    [Display(Name = "Mã nhà sản xuất")]
    public string? Mansx { get; set; }

    public virtual Loaihanghoa? MaloaiNavigation { get; set; }
    public virtual Nhasanxuat? MansxNavigation { get; set; }
    public virtual ICollection<Chitietphieudathang> Chitietphieudathang { get; set; } = new List<Chitietphieudathang>();
    public virtual ICollection<Chitietphieugiaohang> Chitietphieugiaohang { get; set; } = new List<Chitietphieugiaohang>();
}
