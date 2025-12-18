using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class fThanhToan : Form
    {
        // biến lưu id bàn cần thanh toán
        private int idBan;

        // biến lưu tổng tiền gốc (chưa giảm giá) để tính toán
        private decimal tongTienGoc = 0;

        public fThanhToan(int idBanNhanVao)
        {
            InitializeComponent();
            this.idBan = idBanNhanVao;

            // gắn sự kiện load form
            this.Load += FThanhToan_Load;
        }

        private void FThanhToan_Load(object sender, EventArgs e)
        {
            // mặc định chọn loại giảm giá là "Không giảm"
            cboLoaiGiamGia.SelectedIndex = 0;

            // tải dữ liệu hóa đơn
            TaiDuLieuHoaDon();
        }

        // hàm tải dữ liệu từ csdl lên giao diện
        private void TaiDuLieuHoaDon()
        {
            try
            {
                string query = "EXEC usp_LayThongTinThanhToan @idBan";
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@idBan", idBan) };

                // sử dụng ExecuteReader để lấy nhiều bảng dữ liệu cùng lúc
                using (SqlDataReader reader = DataProvider.Instance.ExecuteReader(query, param))
                {
                    // 1. đọc bảng kết quả đầu tiên: thông tin chung (tên bàn, tổng tiền tạm tính...)
                    if (reader.Read())
                    {
                        lblTenBan.Text = reader["TenBan"].ToString() + " - " + reader["ViTri"].ToString();

                        // lưu tổng tiền gốc vào biến toàn cục
                        tongTienGoc = Convert.ToDecimal(reader["TongTienTamTinh"]);
                        lblTongTienGoc.Text = tongTienGoc.ToString("N0") + "đ";
                    }

                    // 2. chuyển sang bảng kết quả thứ hai: chi tiết danh sách món ăn
                    if (reader.NextResult())
                    {
                        dgvChiTiet.Rows.Clear();
                        while (reader.Read())
                        {
                            int index = dgvChiTiet.Rows.Add();
                            dgvChiTiet.Rows[index].Cells[0].Value = reader["TenSP"];
                            dgvChiTiet.Rows[index].Cells[1].Value = Convert.ToDecimal(reader["DonGia"]).ToString("N0");
                            dgvChiTiet.Rows[index].Cells[2].Value = reader["SoLuong"];
                            dgvChiTiet.Rows[index].Cells[3].Value = Convert.ToDecimal(reader["ThanhTien"]).ToString("N0");
                        }
                    }
                }

                // tính toán lại hiển thị lần đầu
                TinhToanTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
                this.Close();
            }
        }

        // hàm tính toán số tiền cuối cùng dựa trên giảm giá
        private void TinhToanTien()
        {
            decimal tienGiam = 0;
            decimal tongTienCuoi = tongTienGoc;
            decimal giaTriNhap = 0;

            // lấy giá trị từ ô nhập liệu, nếu lỗi hoặc rỗng thì coi như là 0
            decimal.TryParse(txtGiamGia.Text.Replace(",", ""), out giaTriNhap);

            int loaiGiam = cboLoaiGiamGia.SelectedIndex;

            if (loaiGiam == 1) // giảm theo %
            {
                // giới hạn max là 100%
                if (giaTriNhap > 100) giaTriNhap = 100;

                tienGiam = tongTienGoc * (giaTriNhap / 100);
            }
            else if (loaiGiam == 2) // giảm theo tiền mặt
            {
                // giới hạn không được giảm quá tổng tiền
                if (giaTriNhap > tongTienGoc) giaTriNhap = tongTienGoc;

                tienGiam = giaTriNhap;
            }

            tongTienCuoi = tongTienGoc - tienGiam;

            // cập nhật lên giao diện
            lblTienGiam.Text = "-" + tienGiam.ToString("N0") + "đ";
            lblFinalTotal.Text = tongTienCuoi.ToString("N0") + "đ";
        }

        // sự kiện khi thay đổi loại giảm giá
        private void CboLoaiGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // nếu chọn "Không giảm" thì khóa ô nhập liệu
            if (cboLoaiGiamGia.SelectedIndex == 0)
            {
                txtGiamGia.Enabled = false;
                txtGiamGia.Text = "0";
            }
            else
            {
                txtGiamGia.Enabled = true;
                txtGiamGia.Focus();
            }
            TinhToanTien();
        }

        // sự kiện khi nhập giá trị giảm giá
        private void TxtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhToanTien();
        }

        // chỉ cho phép nhập số vào ô giảm giá
        private void TxtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // sự kiện nhấn nút xác nhận thanh toán
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn này không?\nTổng tiền: " + lblFinalTotal.Text,
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    decimal giaTriGiam = 0;
                    decimal.TryParse(txtGiamGia.Text, out giaTriGiam);
                    int loaiGiam = cboLoaiGiamGia.SelectedIndex;

                    // gọi store procedure thanh toán
                    string query = "EXEC usp_ThanhToan @idBan , @giamGia , @loaiGiam";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@idBan", idBan),
                        new SqlParameter("@giamGia", giaTriGiam),
                        new SqlParameter("@loaiGiam", loaiGiam)
                    };

                    DataProvider.Instance.ExecuteNonQuery(query, parameters);

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // trả về kết quả ok để form chính biết và load lại bàn
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thanh toán thất bại: " + ex.Message, "Lỗi");
                }
            }
        }

        // sự kiện nhấn nút in hóa đơn tạm
        private void BtnInTam_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in hóa đơn tạm sẽ được cập nhật sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // sự kiện nhấn nút quay lại
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}