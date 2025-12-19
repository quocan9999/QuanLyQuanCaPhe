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
        private bool isAdding = false;
        private bool isEditing = false;
        private BindingSource monList = new BindingSource();

        public fQuanLySanPham()
        {
            InitializeComponent();
        }

        private void fQuanLySanPham_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            SetInputReadOnly(true);
            LockControls(false);

            LoadDanhMucComBoBox(cboDanhMuc);
            LoadData();
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
        // ===========================

        // Load dữ liệu và reset trạng thái form
        private void LoadData()
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

        private List<SanPham> GetListSanPham()
        {
            List<SanPham> list = new List<SanPham>();
            string query = "SELECT * FROM SanPham ORDER BY Id ASC";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow item in data.Rows)
                    list.Add(new SanPham(item));
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
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                cb.DataSource = data;
                cb.DisplayMember = "TenDanhMuc";
                cb.ValueMember = "Id";
            }
            catch { }
        }

        // Kiểm tra tên sản phẩm đã tồn tại chưa
        private bool KiemTraTrungTenSanPham(string tenSanPham, int? idHienTai = null)
        {
            string querySanPham = "SELECT COUNT(*) FROM SanPham WHERE LOWER(LTRIM(RTRIM(TenSP))) = LOWER(@ten)";

            // Nếu đang sửa, loại trừ bản ghi hiện tại
            if (idHienTai.HasValue)
            {
                querySanPham += " AND Id != @id";
                SqlParameter[] paramsSanPham = new SqlParameter[]
                {
                    new SqlParameter("@ten", tenSanPham.Trim()),
                    new SqlParameter("@id", idHienTai.Value)
                };
                return (int)DataProvider.Instance.ExecuteScalar(querySanPham, paramsSanPham) > 0;
            }
            else
            {
                SqlParameter[] paramsSanPham = new SqlParameter[] { new SqlParameter("@ten", tenSanPham.Trim()) };
                return (int)DataProvider.Instance.ExecuteScalar(querySanPham, paramsSanPham) > 0;
            }
        }

        // =====================================================================
        // NÚT CHỨC NĂNG
        // =====================================================================

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

            // Kiểm tra trùng tên sản phẩm
            if (KiemTraTrungTenSanPham(txtTenSanPham.Text))
            {
                MessageBox.Show($"Sản phẩm '{txtTenSanPham.Text.Trim()}' đã tồn tại.\nVui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return;
            }

            try
            {
                string query = "INSERT INTO SanPham (TenSP, DonGia, DonViTinh, MaDanhMuc, TrangThai) VALUES (@ten, @gia, @dvt, @madm, @tt)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ten", txtTenSanPham.Text.Trim()),
                    new SqlParameter("@gia", gia),
                    new SqlParameter("@dvt", txtDVT.Text.Trim()),
                    new SqlParameter("@madm", cboDanhMuc.SelectedValue),
                    new SqlParameter("@tt", txtTrangThai.Text.Trim())
                };

                if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Thêm thành công.");
                    LoadData();
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

            // Kiểm tra trùng tên sản phẩm
            if (KiemTraTrungTenSanPham(txtTenSanPham.Text, id))
            {
                MessageBox.Show($"Sản phẩm '{txtTenSanPham.Text.Trim()}' đã tồn tại.\nVui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return;
            }

            try
            {
                string query = "UPDATE SanPham SET TenSP=@ten, DonGia=@gia, DonViTinh=@dvt, MaDanhMuc=@madm, TrangThai=@tt WHERE Id=@id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@ten", txtTenSanPham.Text.Trim()),
                    new SqlParameter("@gia", float.Parse(txtGia.Text.Trim())),
                    new SqlParameter("@dvt", txtDVT.Text.Trim()),
                    new SqlParameter("@madm", cboDanhMuc.SelectedValue),
                    new SqlParameter("@tt", txtTrangThai.Text.Trim())
                };

                if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Sửa thành công.");
                    LoadData();
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
                string query = "DELETE FROM SanPham WHERE Id = @id";
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", id) };

                if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
                {
                    string reset = "DECLARE @max INT; SELECT @max = ISNULL(MAX(Id),0) FROM SanPham; DBCC CHECKIDENT ('SanPham', RESEED, @max);";
                    DataProvider.Instance.ExecuteNonQuery(reset);

                    MessageBox.Show("Xóa thành công.");
                    LoadData();
                }
            }
            catch { MessageBox.Show("Không thể xóa món này."); }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemMon.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) { LoadData(); return; }

            string query = "SELECT * FROM SanPham WHERE TenSP LIKE @ten ORDER BY Id ASC";
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ten", "%" + keyword + "%") };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
                monList.DataSource = data;
                grvMon.DataSource = monList;
            }
            catch { }
        }
    }
}