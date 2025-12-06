using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyBan : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;
        private string connectionString = "Server=.;Database=QuanLyCaPhe;Trusted_Connection=True;";

        public fQuanLyBan()
        {
            InitializeComponent();
        }

        private void fQuanLyBan_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            txtTrangThai.Text = "Còn trống";

            txtTenBan.Text = "";
            txtViTri.Text = "";
        }

        // ============================
        // LOAD LIST BÀN
        // ============================
        private void LoadListBan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ban", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                grvQuanLyBan.DataSource = data;
            }
        }

        // ============================
        // BINDING
        // ============================
        private void AddBindings()
        {
            ClearBindings();

            txtID.DataBindings.Add("Text", grvQuanLyBan.DataSource, "Id");
            txtTenBan.DataBindings.Add("Text", grvQuanLyBan.DataSource, "TenBan");
            txtViTri.DataBindings.Add("Text", grvQuanLyBan.DataSource, "ViTri");
            txtTrangThai.DataBindings.Add("Text", grvQuanLyBan.DataSource, "TrangThai");
        }

        private void ClearBindings()
        {
            txtID.DataBindings.Clear();
            txtTenBan.DataBindings.Clear();
            txtViTri.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
        }

        // ============================
        // NÚT XEM
        // ============================
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListBan();
            AddBindings();
        }

        // ============================
        // NÚT THÊM
        // ============================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                ClearBindings();
                txtID.Text = "";
                txtTenBan.Text = "";
                txtViTri.Text = "";
                txtTrangThai.Text = "Còn trống";

                isAdding = true;
                btnThem.Text = "Lưu";
                return;
            }

            string tenBan = txtTenBan.Text.Trim();
            string viTri = txtViTri.Text.Trim();
            string trangThai = txtTrangThai.Text.Trim();

            if (tenBan == "" || viTri == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            DialogResult rp = MessageBox.Show("Bạn muốn thêm bàn mới?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rp != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Ban (TenBan, ViTri, TrangThai) OUTPUT INSERTED.Id VALUES (@ten, @vt, @tt)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", tenBan);
                    cmd.Parameters.AddWithValue("@vt", viTri);
                    cmd.Parameters.AddWithValue("@tt", trangThai);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show("Thêm thành công! ID = " + result.ToString());
                        LoadListBan();
                        AddBindings();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }

            isAdding = false;
            btnThem.Text = "Thêm";
        }

        // ============================
        // NÚT SỬA
        // ============================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn bàn cần sửa.", "Thông báo");
                    return;
                }
                txtTenBan.ReadOnly = false;
                txtViTri.ReadOnly = false;
                txtTrangThai.ReadOnly = false;
                grvQuanLyBan.Enabled = false;
                btnSua.Text = "Lưu";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                isEditing = true;
                return;
            }

            int id;
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("ID bàn không hợp lệ.", "Lỗi");
                return;
            }

            string tenBan = txtTenBan.Text.Trim();
            string viTri = txtViTri.Text.Trim();
            string trangThai = txtTrangThai.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenBan) || string.IsNullOrWhiteSpace(viTri) || string.IsNullOrWhiteSpace(trangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bàn.", "Thông báo");
                return;
            }

            DialogResult rp = MessageBox.Show("Bạn muốn lưu thay đổi cho bàn này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rp != DialogResult.Yes)
            {
                txtTenBan.ReadOnly = true;
                txtViTri.ReadOnly = true;
                txtTrangThai.ReadOnly = true;
                grvQuanLyBan.Enabled = true;
                btnSua.Text = "Sửa";
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                isEditing = false;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Ban SET TenBan=@ten, ViTri=@vt, TrangThai=@tt WHERE Id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", tenBan);
                    cmd.Parameters.AddWithValue("@vt", viTri);
                    cmd.Parameters.AddWithValue("@tt", trangThai);
                    cmd.Parameters.AddWithValue("@id", id);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        LoadListBan();
                        AddBindings();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
            }

            txtTenBan.ReadOnly = true;
            txtViTri.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            grvQuanLyBan.Enabled = true;
            btnSua.Text = "Sửa";
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            isEditing = false;
        }
        // ============================
        // NÚT XÓA
        // ============================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvQuanLyBan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa!");
                return;
            }

            int idBan = Convert.ToInt32(grvQuanLyBan.CurrentRow.Cells["Id"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string queryCheck = "SELECT COUNT(*) FROM HoaDon WHERE MaBan = @IdBan";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@IdBan", idBan);
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa! Bàn đã được sử dụng trong hóa đơn.");
                        return;
                    }
                }

                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa bàn này?",
                                                 "Xác nhận",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

                if (r != DialogResult.Yes) return;

                string query = "DELETE FROM Ban WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idBan);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadListBan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }
    }
}
