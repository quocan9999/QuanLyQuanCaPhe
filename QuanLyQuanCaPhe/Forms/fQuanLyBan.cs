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

        // ⭐ Hàm sửa lỗi "sqlCon was null" và "Connection not initialized"
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
            txtViTri.ReadOnly = state;
            txtTrangThai.ReadOnly = state;
        }

        private void fQuanLyBan_Load(object sender, EventArgs e)
        {
            KiemTraKetNoi();
            txtID.ReadOnly = true;
            SetInputReadOnly(true);
            btnXem_Click(null, null); // Tự động nạp dữ liệu khi mở form
        }

        // =====================================================================
        // DỮ LIỆU
        // =====================================================================
        private List<Ban> GetListBan()
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
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
            return list;
        }

        private void LoadListBan()
        {
            grvQuanLyBan.DataSource = GetListBan();
        }

        private void AddBanBinding()
        {
            txtID.DataBindings.Clear();
            txtTenBan.DataBindings.Clear();
            txtViTri.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();

            txtID.DataBindings.Add("Text", grvQuanLyBan.DataSource, "Id");
            txtTenBan.DataBindings.Add("Text", grvQuanLyBan.DataSource, "TenBan");
            txtViTri.DataBindings.Add("Text", grvQuanLyBan.DataSource, "ViTri");
            txtTrangThai.DataBindings.Add("Text", grvQuanLyBan.DataSource, "TrangThai");
        }

        // =====================================================================
        // NÚT CHỨC NĂNG
        // =====================================================================
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

                txtID.DataBindings.Clear();
                txtTenBan.DataBindings.Clear();
                txtViTri.DataBindings.Clear();
                txtTrangThai.DataBindings.Clear();

                txtID.Text = "";
                txtTenBan.Text = "";
                txtViTri.Text = "";
                txtTrangThai.Text = "Còn trống";

                SetInputReadOnly(false);
                LockControls(true);
                txtTenBan.Focus();
                return;
            }
            // xử lý nhập
            if (string.IsNullOrEmpty(txtTenBan.Text.Trim()))
            {
                MessageBox.Show("Tên bàn không được để trống.");
                return;
            }
            if (string.IsNullOrEmpty(txtViTri.Text.Trim()))
            {
                MessageBox.Show("Vị trÍ không được để trống.");
                return;
            }

            KiemTraKetNoi();
            string query = "INSERT INTO Ban (TenBan, ViTri, TrangThai) VALUES (@TenBan, @ViTri, @TrangThai)";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@TenBan", txtTenBan.Text.Trim());
                cmd.Parameters.AddWithValue("@ViTri", txtViTri.Text.Trim());
                cmd.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text.Trim());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm bàn thành công.");
                    btnXem_Click(null, null);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Vui lòng chọn bàn."); return; }
                isEditing = true;
                btnSua.Text = "Lưu";
                btnThem.Enabled = btnXoa.Enabled = false;
                SetInputReadOnly(false);
                LockControls(true);
                return;
            }

            KiemTraKetNoi();
            string query = "UPDATE Ban SET TenBan = @TenBan, ViTri = @ViTri, TrangThai = @TrangThai WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@TenBan", txtTenBan.Text.Trim());
                cmd.Parameters.AddWithValue("@ViTri", txtViTri.Text.Trim());
                cmd.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text.Trim());
                cmd.Parameters.AddWithValue("@Id", txtID.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật bàn thành công.");
                    btnXem_Click(null, null);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                KiemTraKetNoi();
                string query = "DELETE FROM Ban WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Id", txtID.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        // ⭐ Reset Identity
                        string resetQuery = "DECLARE @max INT; SELECT @max = ISNULL(MAX(Id),0) FROM Ban; DBCC CHECKIDENT ('Ban', RESEED, @max);";
                        using (SqlCommand cmdReset = new SqlCommand(resetQuery, sqlCon)) { cmdReset.ExecuteNonQuery(); }

                        MessageBox.Show("Xóa bàn thành công.");
                        btnXem_Click(null, null);
                    }
                }
            }
        }
    }
}