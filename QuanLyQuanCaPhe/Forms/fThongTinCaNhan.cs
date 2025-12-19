using QuanLyQuanCaPhe.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fThongTinCaNhan : Form
    {
        private readonly string _tenDangNhap;

        public fThongTinCaNhan(string tenDangNhap)
        {
            InitializeComponent();
            _tenDangNhap = tenDangNhap;
        }

        #region TẢI VÀ HIỂN THỊ THÔNG TIN NHÂN VIÊN

        private void fThongTinCaNhan_Load(object sender, EventArgs e)
        {
            HienThiThongTinNhanVien();
        }

        private void HienThiThongTinNhanVien()
        {
            if (string.IsNullOrWhiteSpace(_tenDangNhap))
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string queryThongTinNhanVien = @"SELECT HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi FROM NhanVien WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] thamSo =
            {
                new SqlParameter("@TenDangNhap", _tenDangNhap)
            };

            DataTable bangThongTin = DataProvider.Instance.ExecuteQuery(queryThongTinNhanVien, thamSo);

            if (bangThongTin.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow dongThongTin = bangThongTin.Rows[0];

            lblHoTenValue.Text = dongThongTin["HoTen"]?.ToString() ?? "--";
            lblGioiTinhValue.Text = dongThongTin["GioiTinh"]?.ToString() ?? "--";

            if (dongThongTin["NgaySinh"] != DBNull.Value)
            {
                DateTime ngaySinh = Convert.ToDateTime(dongThongTin["NgaySinh"]);
                lblNgaySinhValue.Text = ngaySinh.ToString("dd/MM/yyyy");
            }
            else
            {
                lblNgaySinhValue.Text = "--";
            }

            lblSoDienThoaiValue.Text = dongThongTin["SDT"]?.ToString() ?? "--";
            lblEmailValue.Text = dongThongTin["Email"]?.ToString() ?? "--";
            lblDiaChiValue.Text = dongThongTin["DiaChi"]?.ToString() ?? "--";
        }

        #endregion

        #region ĐÓNG FORM

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
