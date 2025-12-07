
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
        private string connectionString = "Server=.;Database=QuanLyCaPhe;Trusted_Connection=True;";
        private bool isAdding = false;
        private bool isEditing = false;

        // ⭐ Quan trọng: BindingSource
        private BindingSource monList = new BindingSource();

        public fQuanLySanPham()
        {
            InitializeComponent();
        }

        // =====================================================================
        // LẤY LIST SẢN PHẨM
        // =====================================================================
        private List<SanPham> GetListSanPham()
        {
            List<SanPham> list = new List<SanPham>();
            string query = "SELECT * FROM SanPham ORDER BY Id ASC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);

                foreach (DataRow item in data.Rows)
                    list.Add(new SanPham(item));
            }

            return list;
        }

        // =====================================================================
        // LOAD LIST SẢN PHẨM VÀ GÁN CHO BindingSource
        // =====================================================================
        private void LoadListSanPham()
        {
            monList.DataSource = GetListSanPham();
            grvMon.DataSource = monList;
        }

        // =====================================================================
        // BINDING CHUẨN – KHÔNG LỖI MaDanhMuc
        // =====================================================================
        private void AddSanPhamBinding()
        {
            txtTenSanPham.DataBindings.Clear();
            txtID.DataBindings.Clear();
            txtGia.DataBindings.Clear();
            txtDVT.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
            cboDanhMuc.DataBindings.Clear();

            txtTenSanPham.DataBindings.Add("Text", monList, "TenSP");
            txtID.DataBindings.Add("Text", monList, "Id");
            txtGia.DataBindings.Add("Text", monList, "DonGia");
            txtDVT.DataBindings.Add("Text", monList, "DonViTinh");
            txtTrangThai.DataBindings.Add("Text", monList, "TrangThai");

            cboDanhMuc.DataBindings.Add(
                new Binding("SelectedValue", monList, "MaDanhMuc", true, DataSourceUpdateMode.Never)
            );
        }


        // =====================================================================
        // NÚT XEM
        // =====================================================================
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDanhMucComBoBox(cboDanhMuc);
            LoadListSanPham();
            AddSanPhamBinding();
        }

        // =====================================================================
        // NÚT THÊM
        // =====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
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
                if (cboDanhMuc.Items.Count > 0)
                    cboDanhMuc.SelectedIndex = 0;

                txtTenSanPham.Focus();
                isAdding = true;
                btnThem.Text = "Lưu";
                return;
            }

            string TenSP = txtTenSanPham.Text.Trim();
            if (string.IsNullOrEmpty(TenSP))
            {
                MessageBox.Show("Tên món không được để trống.");
                return;
            }

            if (!float.TryParse(txtGia.Text.Trim(), out float DonGia))
            {
                MessageBox.Show("Đơn giá phải là số.");
                return;
            }

            string DonViTinh = txtDVT.Text.Trim();
            if (string.IsNullOrEmpty(DonViTinh))
            {
                MessageBox.Show("Đơn vị tính không được để trống.");
                return;
            }

            int MaDanhMuc = (int)cboDanhMuc.SelectedValue;
            string TrangThai = txtTrangThai.Text.Trim();

            if (TrangThai != "Còn bán" && TrangThai != "Hết")
            {
                MessageBox.Show("Trạng thái chỉ 'Còn bán' hoặc 'Hết'.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE TenSP = @TenSP";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TenSP", TenSP);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tên món đã tồn tại.");
                        return;
                    }
                }

                string query = "INSERT INTO SanPham (TenSP, DonGia, DonViTinh, MaDanhMuc, TrangThai) VALUES (@ten, @gia, @dvt, @madm, @tt)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", TenSP);
                    cmd.Parameters.AddWithValue("@gia", DonGia);
                    cmd.Parameters.AddWithValue("@dvt", DonViTinh);
                    cmd.Parameters.AddWithValue("@madm", MaDanhMuc);
                    cmd.Parameters.AddWithValue("@tt", TrangThai);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm món thành công.");
                        LoadListSanPham();
                        AddSanPhamBinding();
                    }
                    else MessageBox.Show("Lỗi thêm món.");
                }
            }

            isAdding = false;
            btnThem.Text = "Thêm";
        }

        // =====================================================================
        // NÚT SỬA
        // =====================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Chọn món cần sửa.");
                    return;
                }

                txtTenSanPham.ReadOnly = false;
                txtGia.ReadOnly = false;
                txtDVT.ReadOnly = false;
                txtTrangThai.ReadOnly = false;
                cboDanhMuc.Enabled = true;
                grvMon.Enabled = false;

                btnSua.Text = "Lưu";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                isEditing = true;
                return;
            }

            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }

            string TenSP = txtTenSanPham.Text.Trim();
            if (TenSP == "")
            {
                MessageBox.Show("Tên món không được trống.");
                return;
            }

            if (!float.TryParse(txtGia.Text.Trim(), out float DonGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            string DonViTinh = txtDVT.Text.Trim();
            int MaDanhMuc = (int)cboDanhMuc.SelectedValue;
            string TrangThai = txtTrangThai.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE SanPham SET TenSP=@ten, DonGia=@gia, DonViTinh=@dvt, MaDanhMuc=@madm, TrangThai=@tt WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@ten", TenSP);
                    cmd.Parameters.AddWithValue("@gia", DonGia);
                    cmd.Parameters.AddWithValue("@dvt", DonViTinh);
                    cmd.Parameters.AddWithValue("@madm", MaDanhMuc);
                    cmd.Parameters.AddWithValue("@tt", TrangThai);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Sửa thành công.");
                        LoadListSanPham();
                        AddSanPhamBinding();
                    }
                    else MessageBox.Show("Sửa thất bại.");
                }
            }

            txtTenSanPham.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtDVT.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            cboDanhMuc.Enabled = false;
            grvMon.Enabled = true;

            btnSua.Text = "Sửa";
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            isEditing = false;
        }

        // =====================================================================
        // NÚT XÓA
        // =====================================================================
        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    if (!int.TryParse(txtID.Text.Trim(), out int id))
        //    {
        //        MessageBox.Show("Chọn món để xóa.");
        //        return;
        //    }

        //    if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
        //        return;

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        string query = "DELETE FROM SanPham WHERE Id = @Id";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Id", id);

        //            if (cmd.ExecuteNonQuery() > 0)
        //            {
        //                MessageBox.Show("Xóa thành công.");
        //                LoadListSanPham();
        //                AddSanPhamBinding();
        //            }
        //            else MessageBox.Show("Xóa thất bại.");
        //        }
        //    }
        //}
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text.Trim(), out int id))
            {
                MessageBox.Show("Chọn món để xóa.");
                return;
            }

            if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Xóa dữ liệu
                string deleteQuery = "DELETE FROM SanPham WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        // 2. Reset IDENTITY sau khi xóa
                        string resetIdentity = @"
                    DECLARE @maxId INT;
                    SELECT @maxId = ISNULL(MAX(Id), 0) FROM SanPham;
                    DBCC CHECKIDENT ('SanPham', RESEED, @maxId);
                ";

                        using (SqlCommand resetCmd = new SqlCommand(resetIdentity, conn))
                        {
                            resetCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa thành công và đã reset ID.");
                        LoadListSanPham();
                        AddSanPhamBinding();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.");
                    }
                }
            }
        }


        // =====================================================================
        // LOAD DANH MỤC
        // =====================================================================
        private void LoadDanhMucComBoBox(ComboBox cb)
        {
            string query = "SELECT Id, TenDanhMuc FROM DanhMuc ORDER BY Id";

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



        // =====================================================================
        // FORM LOAD
        // =====================================================================
        private void fQuanLySanPham_Load(object sender, EventArgs e)
        {
          
          
        }

        // =====================================================================
        // NÚT TÌM KIẾM
        // =====================================================================
        // =====================================================================
        // NÚT TÌM KIẾM THEO TÊN SẢN PHẨM
        // =====================================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemMon.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!");
                return;
            }

            string query = "SELECT * FROM SanPham WHERE TenSP LIKE @ten ORDER BY Id ASC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@ten", "%" + keyword + "%");

                DataTable data = new DataTable();
                adapter.Fill(data);

                // Gán kết quả vào BindingSource
                monList.DataSource = data;
                grvMon.DataSource = monList;
            }
        }


    }
}
