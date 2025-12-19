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
        private bool isAdding = false;
        private bool isEditing = false;

        public fQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        #region XỬ LÝ GIAO DIỆN

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
            txtID.ReadOnly = true;
            SetInputReadOnly(true);
            LoadData();
        }

        #endregion

        #region TẢI DỮ LIỆU

        private void LoadData()
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

        private List<DanhMuc> GetListDanhMuc()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            string query = "SELECT * FROM DanhMuc ORDER BY Id ASC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new DanhMuc(item));
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

        #endregion

        #region THÊM - SỬA - XÓA DANH MỤC

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

            string checkQuery = "SELECT COUNT(*) FROM DanhMuc WHERE TenDanhMuc = @ten";
            SqlParameter[] checkParams = new SqlParameter[] { new SqlParameter("@ten", ten) };
            if ((int)DataProvider.Instance.ExecuteScalar(checkQuery, checkParams) > 0)
            {
                MessageBox.Show("Tên đã tồn tại.Bạn vui lòng nhập tên khác");
                return;
            }

            string query = "INSERT INTO DanhMuc (TenDanhMuc) VALUES (@ten)";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ten", ten) };
            if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
            {
                MessageBox.Show("Thêm thành công.");
                LoadData();
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

            string query = "UPDATE DanhMuc SET TenDanhMuc = @ten WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten", txtDanhMuc.Text.Trim()),
                new SqlParameter("@id", txtID.Text)
            };
            if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM DanhMuc WHERE Id = @id";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", txtID.Text) };
                    if (DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0)
                    {
                        string resetQuery = "DECLARE @max INT; SELECT @max = ISNULL(MAX(Id),0) FROM DanhMuc; DBCC CHECKIDENT ('DanhMuc', RESEED, @max);";
                        DataProvider.Instance.ExecuteNonQuery(resetQuery);
                        MessageBox.Show("Xóa thành công.");
                        LoadData();
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi: Danh mục này đang có sản phẩm, không thể xóa!");
                }
            }
        }

        #endregion
    }
}