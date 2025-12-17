using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        public bool Login(string username, string password)
        {
            string query = "usp_Login @userName, @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new SqlParameter[]
            {
                new SqlParameter("@userName", username),
                new SqlParameter("@passWord", password)
            });
            return result.Rows.Count > 0;
        }
        //Kiểm tra tên đăng nhập hoặc mật khẩu không được để trống và không được có khoảng trắng
        private bool ValidateInput(string userName, string passWord)
        {
            // Kiểm tra để trống
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra có khoảng trắng không
            if (userName.Contains(" "))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (passWord.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTenDangNhap.Text;
            string passWord = txtMatKhau.Text;

            if (!ValidateInput(userName, passWord))
            {
                return;
            }

            string query = "EXEC usp_Login @userName = '" + userName + "' , @passWord = '" + passWord + "'";
            DataTable duLieu = DataProvider.Instance.ExecuteQuery(query);

            if (duLieu.Rows.Count > 0)
            {
                DataRow hangDuLieu = duLieu.Rows[0];
                LuuTruThongTinDangNhap.TenDangNhap = hangDuLieu["TenDangNhap"].ToString();
                LuuTruThongTinDangNhap.VaiTro = hangDuLieu["VaiTro"].ToString();
                LuuTruThongTinDangNhap.HoTen = hangDuLieu["HoTen"].ToString();

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain f = new fMain();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
