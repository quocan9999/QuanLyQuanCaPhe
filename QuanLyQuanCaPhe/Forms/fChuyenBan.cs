using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class fChuyenBan : Form
    {
        // biến lưu id của bàn hiện tại (bàn nguồn)
        private int idBanCu;
        private string tenBanCu;

        public fChuyenBan(int idBan)
        {
            InitializeComponent();
            this.idBanCu = idBan;

            TaiThongTinBanHienTai();
            TaiDanhSachBanTrong();
        }

        // hàm lấy tên và vị trí của bàn hiện tại để hiển thị
        private void TaiThongTinBanHienTai()
        {
            string query = "SELECT * FROM Ban WHERE Id = " + idBanCu;
            DataTable duLieu = DataProvider.Instance.ExecuteQuery(query);

            if (duLieu.Rows.Count > 0)
            {
                DataRow dong = duLieu.Rows[0];
                tenBanCu = dong["TenBan"].ToString();
                string viTri = dong["ViTri"].ToString();

                lblBanHienTai.Text = "Bàn hiện tại: " + tenBanCu + " (" + viTri + ")";
            }
            else
            {
                lblBanHienTai.Text = "Bàn hiện tại: không tìm thấy!";
            }
        }

        // hàm tải danh sách các bàn còn trống vào combobox
        private void TaiDanhSachBanTrong()
        {
            // lấy tất cả bàn có trạng thái 'Còn trống' và khác bàn hiện tại
            string query = "SELECT * FROM Ban WHERE TrangThai = N'Còn trống' AND Id != " + idBanCu;
            DataTable duLieu = DataProvider.Instance.ExecuteQuery(query);

            // tạo một bảng dữ liệu mới để hiển thị đẹp hơn
            DataTable bangHienThi = new DataTable();
            bangHienThi.Columns.Add("Id", typeof(int));
            bangHienThi.Columns.Add("TenHienThi", typeof(string));

            foreach (DataRow dong in duLieu.Rows)
            {
                string ten = dong["TenBan"].ToString();
                string viTri = dong["ViTri"].ToString();
                int id = (int)dong["Id"];

                // format tên hiển thị: Bàn 5 - Tầng 2
                bangHienThi.Rows.Add(id, ten + " - " + viTri);
            }

            if (bangHienThi.Rows.Count > 0)
            {
                cboBanMoi.DataSource = bangHienThi;
                cboBanMoi.DisplayMember = "TenHienThi";
                cboBanMoi.ValueMember = "Id";
                cboBanMoi.SelectedIndex = 0;
            }
            else
            {
                cboBanMoi.DataSource = null;
                cboBanMoi.Items.Add("-- Không còn bàn trống --");
                cboBanMoi.SelectedIndex = 0;
                cboBanMoi.Enabled = false;
                btnXacNhan.Enabled = false;
            }
        }

        // sự kiện nhấn nút xác nhận chuyển bàn
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (cboBanMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn chuyển tới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // lấy id bàn mới từ combobox
            int idBanMoi = (int)cboBanMoi.SelectedValue;
            string tenBanMoi = cboBanMoi.Text;

            if (MessageBox.Show("Bạn có chắc muốn chuyển từ " + tenBanCu + " sang " + tenBanMoi + " không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // gọi store procedure chuyển bàn đã tạo trong sql
                    string query = "EXEC usp_ChuyenBan @idBanCu , @idBanMoi";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@idBanCu", idBanCu),
                        new SqlParameter("@idBanMoi", idBanMoi)
                    };

                    // Truyền mảng parameters vào thay vì object[]
                    DataProvider.Instance.ExecuteNonQuery(query, parameters);

                    MessageBox.Show("Chuyển bàn thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chuyển bàn: " + ex.Message, "Lỗi");
                }
            }
        }

        // sự kiện nhấn nút hủy
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}