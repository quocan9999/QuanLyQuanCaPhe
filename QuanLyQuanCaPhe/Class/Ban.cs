using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Class
{
    internal class Ban
    {
        public int Id { get; set; }
        public string TenBan { get; set; }
        public string ViTri { get; set; }
        public string TrangThai { get; set; }
        public Ban(int id, string tenBan, string viTri, string trangThai)
        {
            this.Id = id;
            this.TenBan = tenBan;
            this.ViTri = viTri;
            this.TrangThai = trangThai;
        }
        public Ban(DataRow row) 
        {
            this.Id = (int)row["Id"];
            this.TenBan = row["TenBan"].ToString();
            this.ViTri = row["ViTri"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }
    }
}
