using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Class
{
    internal class NhanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public float Luong {  get; set; }
        public string TrangThai { get; set; }
        public string TenDangNhap { get; set; }
        public NhanVien(int id, string hoTen, string gioiTinh, string ngaySinh, int sDT, string email, string diaChi, float luong, string trangThai, string tenDangNhap)
        {
            this.Id = id;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.SDT = SDT;
            this.Email = email;
            this.DiaChi = diaChi;
            this.Luong = luong;
            this.TrangThai = trangThai;
            this.TenDangNhap = tenDangNhap;
        }
        public NhanVien(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.HoTen = row["HoTen"].ToString();
            this.GioiTinh = row["GioiTinh"].ToString();
            this.NgaySinh = row["NgaySinh"].ToString();
            this.SDT = row["SDT"].ToString();
            this.Email = row["Email"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.Luong = (float)Convert.ToDouble(row["Luong"].ToString());
            this.TrangThai = row["TrangThai"].ToString();
            this.TenDangNhap = row["TenDangNhap"].ToString();
        }
       
    }
}
