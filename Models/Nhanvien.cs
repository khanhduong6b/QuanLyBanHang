using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models;

public partial class Nhanvien
{
    [DisplayName("Mã số nhân viên")]
    [Required(ErrorMessage ="Chưa nhập mã số nhân viên")]
    public string Manv { get; set; } = null!;
    [DisplayName("Tên nhân viên")]
    [Required(ErrorMessage = "Chưa nhập tên nhân viên")]
    public string? Tennv { get; set; }
    [DisplayName("Ngày sinh")]
    [Required(ErrorMessage = "Chưa nhập ngày sinh nhân viên")]
    public DateTime? Ngaysinh { get; set; }
    [DisplayName("Giới tính")]
    [Required(ErrorMessage = "Chưa chọn giới tính")]
    public bool? Phai { get; set; }
    [DisplayName("Địa chỉ")]
    public string? Diachi { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; } = new List<Phieugiaohang>();
}
