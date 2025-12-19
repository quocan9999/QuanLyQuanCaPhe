using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyBan : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;

        public fQuanLyBan()
        {
            InitializeComponent();
        }

        #region XỬ LÝ GIAO DIỆN

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
            txtID.ReadOnly = true;
            SetInputReadOnly(true);
            LoadData();
        }

        #endregion

        #region TẢI DỮ LIỆU

        private void LoadData()
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

        private List<Ban> GetListBan()
        {
            List<Ban> list = new List<Ban>();
            string query = "SELECT * FROM Ban ORDER BY Id ASC";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow item in data.Rows)
                {
                    list.Add(new Ban(item));
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

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private string ChuanHoaTenBan(string tenBan)
        {
            if (string.IsNullOrEmpty(tenBan)) return "";
            return Regex.Replace(tenBan.Trim(), @"(\d+)", m => int.Parse(m.Value).ToString());
        }

        private bool KiemTraTrungTenBan(string tenBan, string viTri, int? idHienTai = null)
        {
            string tenBanChuanHoa = ChuanHoaTenBan(tenBan).ToLower();
            string query = "SELECT Id, TenBan FROM Ban WHERE ViTri = @ViTri";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ViTri", viTri.Trim()) };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                string tenBanTrongDB = row["TenBan"].ToString();
                if (idHienTai.HasValue && id == idHienTai.Value) continue;
                if (ChuanHoaTenBan(tenBanTrongDB).ToLower() == tenBanChuanHoa) return true;
            }
            return false;
        }

        #endregion

        #region THÊM - SỬA - XÓA BÀN

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
            if (string.IsNullOrEmpty(txtTenBan.Text.Trim())) { MessageBox.Show("Tên bàn không được để trống."); return; }
            if (string.IsNullOrEmpty(txtViTri.Text.Trim())) { MessageBox.Show("Vị trí không được để trống."); return; }

            string tenBanDaXuLy = ChuanHoaTenBan(txtTenBan.Text);
            if (KiemTraTrungTenBan(tenBanDaXuLy, txtViTri.Text))
            {
                MessageBox.Show($"Tên bàn '{tenBanDaXuLy}' đã tồn tại trong khu vực '{txtViTri.Text.Trim()}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Ban (TenBan, ViTri, TrangThai) VALUES (@TenBan, @ViTri, @TrangThai)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenBan", tenBanDaXuLy),
                new SqlParameter("@ViTri", txtViTri.Text.Trim()),
                new SqlParameter("@TrangThai", txtTrangThai.Text.Trim())
            };
            if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0) { MessageBox.Show("Thêm bàn thành công."); LoadData(); }
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
            string tenBanDaXuLy = ChuanHoaTenBan(txtTenBan.Text);
            int idHienTai = int.Parse(txtID.Text);
            if (KiemTraTrungTenBan(tenBanDaXuLy, txtViTri.Text, idHienTai))
            {
                MessageBox.Show($"Tên bàn '{tenBanDaXuLy}' đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE Ban SET TenBan = @TenBan, ViTri = @ViTri, TrangThai = @TrangThai WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenBan", tenBanDaXuLy),
                new SqlParameter("@ViTri", txtViTri.Text.Trim()),
                new SqlParameter("@TrangThai", txtTrangThai.Text.Trim()),
                new SqlParameter("@Id", txtID.Text)
            };
            if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0) { MessageBox.Show("Cập nhật thành công."); LoadData(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Ban WHERE Id = @Id";
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Id", txtID.Text) };
                if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
                {
                    string resetQuery = "DECLARE @max INT; SELECT @max = ISNULL(MAX(Id),0) FROM Ban; DBCC CHECKIDENT ('Ban', RESEED, @max);";
                    DataProvider.Instance.ExecuteNonQuery(resetQuery);
                    MessageBox.Show("Xóa bàn thành công.");
                    LoadData();
                }
            }
        }

        #endregion
    }
}