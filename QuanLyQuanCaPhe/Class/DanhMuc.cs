using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Class
{
    internal class DanhMuc
    {
        public int Id { get; set; }
        public string TenDanhMuc { get; set; }
        public DanhMuc(int Id,string TenDanhMuc)
        {
            this.Id = Id;
            this.TenDanhMuc = TenDanhMuc;

        }
        public DanhMuc(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.TenDanhMuc = row["TenDanhMuc"].ToString();
        }
    }
}
