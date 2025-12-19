using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLySanPham : Form
    {
        private string connectionString = "Data Source = .\\SQLEXPRESS; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True";
        private SqlConnection sqlCon = null;
        private bool isAdding = false;
        private bool isEditing = false;
        private BindingSource monList = new BindingSource();

        public fQuanLySanPham()
        {
            InitializeComponent();
        }

        private void fQuanLySanPham_Load(object sender, EventArgs e)
        {
            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);

            txtID.ReadOnly = true;
            SetInputReadOnly(true);
            LockControls(false);

           
            LoadDanhMucComBoBox(cboDanhMuc);
        }

        // ==========================
        //QUẢN LÝ GIAO DIỆN 
        // ==========================
        private void SetInputReadOnly(bool state)
        {
            txtTenSanPham.ReadOnly = state;
            txtGia.ReadOnly = state;
            txtDVT.ReadOnly = state;
            txtTrangThai.ReadOnly = state;
            cboDanhMuc.Enabled = !state;
        }

        private void LockControls(bool lockState)
        {
            grvMon.Enabled = !lockState; 
        }

        // ===========================
        // DỮ LIỆU 
        // ==========================
        private List<SanPham> GetListSanPham()
        {
            List<SanPham> list = new List<SanPham>();
            string query = "SELECT * FROM SanPham ORDER BY Id ASC";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    foreach (DataRow item in data.Rows)
                        list.Add(new SanPham(item));
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load: " + ex.Message); }
            return list;
        }
        private void LoadListSanPham()
        {
            monList.DataSource = GetListSanPham();
            grvMon.DataSource = monList;
        }
        private void AddSanPhamBinding()
        {
            txtID.DataBindings.Clear();
            txtTenSanPham.DataBindings.Clear();
            txtGia.DataBindings.Clear();
            txtDVT.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
            cboDanhMuc.DataBindings.Clear();

            txtID.DataBindings.Add("Text", monList, "Id", true, DataSourceUpdateMode.Never);
            txtTenSanPham.DataBindings.Add("Text", monList, "TenSP", true, DataSourceUpdateMode.Never);
            txtGia.DataBindings.Add("Text", monList, "DonGia", true, DataSourceUpdateMode.Never);
            txtDVT.DataBindings.Add("Text", monList, "DonViTinh", true, DataSourceUpdateMode.Never);
            txtTrangThai.DataBindings.Add("Text", monList, "TrangThai", true, DataSourceUpdateMode.Never);
            cboDanhMuc.DataBindings.Add(new Binding("SelectedValue", monList, "MaDanhMuc", true, DataSourceUpdateMode.Never));
        }

        private void LoadDanhMucComBoBox(ComboBox cb)
        {
            string query = "SELECT Id, TenDanhMuc FROM DanhMuc ORDER BY Id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    cb.DataSource = data;
                    cb.DisplayMember = "TenDanhMuc";
                    cb.ValueMember = "Id";
                }
            }
            catch { }
        }

        // ================
        // NÚT XEM
        // ==================
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListSanPham();
            AddSanPhamBinding();
            SetInputReadOnly(true);
            LockControls(false);
            isAdding = isEditing = false;
            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
        }

        // ==============
        // NÚT THÊM
        // ==============
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                btnThem.Text = "Lưu";
                btnSua.Enabled = btnXoa.Enabled = false;

                txtID.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();
                txtGia.DataBindings.Clear();
                txtDVT.DataBindings.Clear();
                txtTrangThai.DataBindings.Clear();
                cboDanhMuc.DataBindings.Clear();

                txtID.Text = "";
                txtTenSanPham.Text = "";
                txtGia.Text = "";
                txtDVT.Text = "";
                txtTrangThai.Text = "Còn bán";

                SetInputReadOnly(false);
                LockControls(true);
                txtTenSanPham.Focus();
                return;
            }

            // Xử lý LƯU THÊM
            if (string.IsNullOrEmpty(txtTenSanPham.Text)) { MessageBox.Show("Tên không được để trống."); return; }
            if (!float.TryParse(txtGia.Text, out float gia)) { MessageBox.Show("Nhập giá là số ."); return; }
            if (string.IsNullOrEmpty(txtDVT.Text)) { MessageBox.Show(" Đon vị tính không được để trống."); return; }

            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query = "INSERT INTO SanPham (TenSP, DonGia, DonViTinh, MaDanhMuc, TrangThai) VALUES (@ten, @gia, @dvt, @madm, @tt)";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@ten", txtTenSanPham.Text.Trim());
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@dvt", txtDVT.Text.Trim());
                    cmd.Parameters.AddWithValue("@madm", cboDanhMuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@tt", txtTrangThai.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm thành công.");
                        btnXem_Click(null, null);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // ==============
        // NÚT SỬA
        // ==============
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Chọn món cần sửa."); return; }
                isEditing = true;
                btnSua.Text = "Lưu";
                btnThem.Enabled = btnXoa.Enabled = false;
                SetInputReadOnly(false);
                LockControls(true);
                return;
            }

            // Xử lý LƯU SỬA
            if (!int.TryParse(txtID.Text, out int id)) return;
            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query = "UPDATE SanPham SET TenSP=@ten, DonGia=@gia, DonViTinh=@dvt, MaDanhMuc=@madm, TrangThai=@tt WHERE Id=@id";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@ten", txtTenSanPham.Text.Trim());
                    cmd.Parameters.AddWithValue("@gia", float.Parse(txtGia.Text.Trim()));
                    cmd.Parameters.AddWithValue("@dvt", txtDVT.Text.Trim());
                    cmd.Parameters.AddWithValue("@madm", cboDanhMuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@tt", txtTrangThai.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Sửa thành công.");
                        btnXem_Click(null, null);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // ==============
        // NÚT XÓA
        // ==============
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id)) return;
            if (MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query = "DELETE FROM SanPham WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        string reset = "DECLARE @max INT; SELECT @max = ISNULL(MAX(Id),0) FROM SanPham; DBCC CHECKIDENT ('SanPham', RESEED, @max);";
                        using (SqlCommand cmdReset = new SqlCommand(reset, sqlCon)) { cmdReset.ExecuteNonQuery(); }

                        MessageBox.Show("Xóa thành công.");
                        btnXem_Click(null, null);
                    }
                }
            }
            catch { MessageBox.Show("Không thể xóa món này."); }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemMon.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) { btnXem_Click(null, null); return; }

            string query = "SELECT * FROM SanPham WHERE TenSP LIKE @ten ORDER BY Id ASC";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ten", "%" + keyword + "%");
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    monList.DataSource = data;
                    grvMon.DataSource = monList;
                }
            }
            catch { }
        }
    }
}