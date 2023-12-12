using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models;

public partial class Nhasanxuat
{
    [DisplayName("Mã nhà sản xuất")]
    [Required(ErrorMessage = "Mã nhà sản xuất không được để trống!")]
    public string Mansx { get; set; } = null!;


    [DisplayName("Tên nhà sản xuất")]
    [Required(ErrorMessage = "Tên nhà sản xuất không được để trống!")]
    public string? Tennsx { get; set; }

    [DisplayName("Địa chỉ")]
    [Required(ErrorMessage = "Địa chỉ nhà sản xuất không được để trống!")]
    public string? Diachi { get; set; }

    public virtual ICollection<Hanghoa> Hanghoas { get; set; } = new List<Hanghoa>();
}
