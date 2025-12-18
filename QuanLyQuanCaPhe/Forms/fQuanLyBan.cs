using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyBan : Form
    {
        private string connectionString = "Server=.;Database=QuanLyCaPhe;Trusted_Connection=True;";
        private SqlConnection sqlCon = null;
        private bool isAdding = false;
        private bool isEditing = false;

        public fQuanLyBan()
        {
            InitializeComponent();
        }

        private void KiemTraKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        private void LockControls(bool lockState)
        {
            grvQuanLyBan.Enabled = !lockState;
        }

        private void SetInputReadOnly(bool state)
        {
            txtTenBan.ReadOnly = state;
            txtTrangThai.ReadOnly = state;
            // ComboBox phải Enabled mới hiện danh sách cho chọn
            cboViTri.Enabled = !state;
        }

        private void KhoiTaoComboBoxViTri()
        {
            cboViTri.Items.Clear();
            cboViTri.Items.Add("Tầng trệt");
            cboViTri.Items.Add("Lầu 1");
            cboViTri.Items.Add("Lầu 2");
            cboViTri.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fQuanLyBan_Load(object sender, EventArgs e)
        {
            KiemTraKetNoi();
            txtID.ReadOnly = true;
            KhoiTaoComboBoxViTri();
            SetInputReadOnly(true);
            btnXem_Click(null, null);
        }

        private void LoadListBan()
        {
            List<Ban> list = new List<Ban>();
            string query = "SELECT * FROM Ban ORDER BY Id ASC";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    foreach (DataRow item in data.Rows)
                    {
                        list.Add(new Ban(item));
                    }
                }
                grvQuanLyBan.DataSource = list;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void AddBanBinding()
        {
            txtID.DataBindings.Clear();
            txtTenBan.DataBindings.Clear();
            cboViTri.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();

            txtID.DataBindings.Add("Text", grvQuanLyBan.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtTenBan.DataBindings.Add("Text", grvQuanLyBan.DataSource, "TenBan", true, DataSourceUpdateMode.Never);
            cboViTri.DataBindings.Add("Text", grvQuanLyBan.DataSource, "ViTri", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTrangThai.DataBindings.Add("Text", grvQuanLyBan.DataSource, "TrangThai", true, DataSourceUpdateMode.Never);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListBan();
            AddBanBinding();
            SetInputReadOnly(true);
            LockControls(false);
            isAdding = isEditing = false;
            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                btnThem.Text = "Lưu";
                btnSua.Enabled = btnXoa.Enabled = false;

                // 1. GỠ BINDING TRƯỚC
                txtID.DataBindings.Clear();
                txtTenBan.DataBindings.Clear();
                cboViTri.DataBindings.Clear();
                txtTrangThai.DataBindings.Clear();

                // 2. MỞ KHÓA CONTROL
                SetInputReadOnly(false);

                // 3. LÀM TRỐNG VÀ GÁN GIÁ TRỊ MẶC ĐỊNH
                txtID.Text = "";
                txtTenBan.Text = "";
                txtTrangThai.Text = "Còn trống";

                // ĐẢM BẢO LOAD LẠI DỮ LIỆU CỨNG VÀ CHỌN
                KhoiTaoComboBoxViTri();
                if (cboViTri.Items.Count > 0) cboViTri.SelectedIndex = 0;

                LockControls(true);
                txtTenBan.Focus();
                return;
            }

            // XỬ LÝ LƯU (INSERT)
            if (string.IsNullOrEmpty(txtTenBan.Text.Trim())) { MessageBox.Show("Nhập tên bàn!"); return; }

            KiemTraKetNoi();
            string query = "INSERT INTO Ban (TenBan, ViTri, TrangThai) VALUES (@Ten, @VT, @TT)";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@Ten", txtTenBan.Text.Trim());
                cmd.Parameters.AddWithValue("@VT", cboViTri.Text);
                cmd.Parameters.AddWithValue("@TT", txtTrangThai.Text.Trim());
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Thêm thành công!");
            btnXem_Click(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (string.IsNullOrEmpty(txtID.Text)) return;
                isEditing = true;
                btnSua.Text = "Lưu";
                btnThem.Enabled = btnXoa.Enabled = false;

                // Gỡ binding riêng cho cbo để nó không bị nhảy khi chọn
                string currentVT = cboViTri.Text;
                cboViTri.DataBindings.Clear();
                cboViTri.Text = currentVT;

                SetInputReadOnly(false);
                LockControls(true);
                return;
            }

            // XỬ LÝ LƯU (UPDATE)
            KiemTraKetNoi();
            string query = "UPDATE Ban SET TenBan = @Ten, ViTri = @VT, TrangThai = @TT WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@Ten", txtTenBan.Text.Trim());
                cmd.Parameters.AddWithValue("@VT", cboViTri.Text);
                cmd.Parameters.AddWithValue("@TT", txtTrangThai.Text.Trim());
                cmd.Parameters.AddWithValue("@Id", txtID.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Sửa thành công!");
            btnXem_Click(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Xóa bàn?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                KiemTraKetNoi();
                string query = "DELETE FROM Ban WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Id", txtID.Text);
                    cmd.ExecuteNonQuery();
                }
                btnXem_Click(null, null);
            }
        }
    }
}