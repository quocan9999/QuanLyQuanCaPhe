using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Class
{
    internal class NguoiDung
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }

        public NguoiDung(string tenDangNhap, string matKhau, string vaiTro, DateTime ngayTao, string trangThai)
        {
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.VaiTro = vaiTro;
            this.NgayTao = ngayTao;
            this.TrangThai = trangThai;
        }

        public NguoiDung(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.VaiTro = row["VaiTro"].ToString();
            this.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            this.TrangThai = row["TrangThai"].ToString();
        }
    }
}
