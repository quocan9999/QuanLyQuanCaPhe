using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyDanhMuc : Form
    {
        private string connectionString = "Server=.;Database=QuanLyCaPhe;Trusted_Connection=True;";
        private SqlConnection sqlCon = null;
        private bool isAdding = false;
        private bool isEditing = false;

        public fQuanLyDanhMuc()
        {
            InitializeComponent();
        }
        private void KiemTraKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        private void SetInputReadOnly(bool state)
        {
            txtDanhMuc.ReadOnly = state;
        }

        private void LockControls(bool lockState)
        {
            grvDanhMuc.Enabled = !lockState;
        }

        private void fQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            KiemTraKetNoi();
            txtID.ReadOnly = true;
            SetInputReadOnly(true);
        }

        // ===================
        // DỮ LIỆU
        // ===================
        private List<DanhMuc> GetListDanhMuc()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            string query = "SELECT * FROM DanhMuc ORDER BY Id ASC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                foreach (DataRow item in data.Rows)
                {
                    list.Add(new DanhMuc(item));
                }
            }
            return list;
        }

        private void LoadListDanhMuc()
        {
            grvDanhMuc.DataSource = GetListDanhMuc();
        }

        private void AddDanhMucBinding()
        {
            txtID.DataBindings.Clear();
            txtDanhMuc.DataBindings.Clear();
            txtID.DataBindings.Add("Text", grvDanhMuc.DataSource, "Id");
            txtDanhMuc.DataBindings.Add("Text", grvDanhMuc.DataSource, "TenDanhMuc");
        }

        // ========================
        // CÁC NÚT CHỨC NĂNG
        // ========================
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListDanhMuc();
            AddDanhMucBinding();
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
                txtDanhMuc.DataBindings.Clear();
                txtID.Text = "";
                txtDanhMuc.Text = "";

                SetInputReadOnly(false);
                LockControls(true);
                txtDanhMuc.Focus();
                return;
            }

            string ten = txtDanhMuc.Text.Trim();
            if (string.IsNullOrEmpty(ten)) { MessageBox.Show("Tên danh mục không được trống."); return; }

            KiemTraKetNoi(); 

            // Kiểm tra trùng tên
            string checkQuery = "SELECT COUNT(*) FROM DanhMuc WHERE TenDanhMuc = @ten";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlCon))
            {
                checkCmd.Parameters.AddWithValue("@ten", ten);
                if ((int)checkCmd.ExecuteScalar() > 0) { MessageBox.Show("Tên đã tồn tại.Bạn vui lòng nhập tên khác"); return; }
            }

            string query = "INSERT INTO DanhMuc (TenDanhMuc) VALUES (@ten)";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@ten", ten);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công.");
                    btnXem_Click(null, null); // Tự động load lại
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Hãy chọn danh mục."); return; }
                isEditing = true;
                btnSua.Text = "Lưu";
                btnThem.Enabled = btnXoa.Enabled = false;
                SetInputReadOnly(false);
                LockControls(true);
                return;
            }

            KiemTraKetNoi();
            string query = "UPDATE DanhMuc SET TenDanhMuc = @ten WHERE Id = @id";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@ten", txtDanhMuc.Text.Trim());
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật thành công.");
                    btnXem_Click(null, null);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    KiemTraKetNoi();
                    string query = "DELETE FROM DanhMuc WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // RESET ID
                            string resetQuery = "DECLARE @max INT; SELECT @max = ISNULL(MAX(Id),0) FROM DanhMuc; DBCC CHECKIDENT ('DanhMuc', RESEED, @max);";
                            using (SqlCommand cmdReset = new SqlCommand(resetQuery, sqlCon)) { cmdReset.ExecuteNonQuery(); }

                            MessageBox.Show("Xóa thành công.");
                            btnXem_Click(null, null);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi: Danh mục này đang có sản phẩm, không thể xóa!");
                }
            }
        }
    }
}