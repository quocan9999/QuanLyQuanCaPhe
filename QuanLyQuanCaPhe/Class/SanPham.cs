using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Class
{
    internal class SanPham
    {
        public int Id { get; set; }
        public string TenSP { get; set; }
        public float DonGia {  get; set; }
        public string DonViTinh { get; set; }
        public int MaDanhMuc { get; set; }
        public string TrangThai { get; set; }   
        public SanPham(int Id,string TenSp,float DonGia,string DonViTinh,int MaDanhMuc,string TrangThai) 
        {
            this.Id = Id;
            this.TenSP = TenSp;
            this.DonGia = DonGia;
            this.DonViTinh = DonViTinh;
            this.MaDanhMuc = MaDanhMuc;
            this.TrangThai = TrangThai;
        }
        public SanPham(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.TenSP = row["TenSp"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["DonGia"].ToString());
            this.DonViTinh = row["DonViTinh"].ToString();
            this.MaDanhMuc = (int)row["MaDanhMuc"];
            this.TrangThai = row["TrangThai"].ToString();

        }
    }
}
