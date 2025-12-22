using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QuanLyQuanCaPhe
{
    public partial class fInHoaDon : Form
    {
        private int idBanCanIn;
        private decimal giamGiaInput;
        private int loaiGiamInput;

        public fInHoaDon(int idBan, decimal giamGia, int loaiGiam)
        {
            InitializeComponent();
            this.idBanCanIn = idBan;
            this.giamGiaInput = giamGia;
            this.loaiGiamInput = loaiGiam;
        }

        #region TẢI VÀ HIỂN THỊ BÁO CÁO HÓA ĐƠN

        private void fInHoaDon_Load(object sender, EventArgs e)
        {
            TaiHoaDonLenBaoCao();
        }

        private void TaiHoaDonLenBaoCao()
        {
            try
            {
                dsHoaDon ds = new dsHoaDon();

                using (SqlConnection conn = new SqlConnection(DataProvider.Instance.ConnectionString))
                {
                    conn.Open();
                    string query = "EXEC usp_InHoaDon @idBan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idBan", idBanCanIn);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds.dtHoaDon);
                        }
                    }
                }

                if (ds.dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo");
                    this.Close();
                    return;
                }

                // tính toán tiền giảm giá
                foreach (dsHoaDon.dtHoaDonRow row in ds.dtHoaDon.Rows)
                {
                    decimal tongGoc = row.TongTienGoc;
                    decimal tienGiam = 0;

                    if (loaiGiamInput == 1) // %
                    {
                        row.GiamGiaPhanTram = giamGiaInput;
                        row.GiamGiaTien = 0;
                        tienGiam = tongGoc * (giamGiaInput / 100);
                    }
                    else if (loaiGiamInput == 2) // tiền
                    {
                        row.GiamGiaPhanTram = 0;
                        row.GiamGiaTien = giamGiaInput;
                        tienGiam = giamGiaInput;
                    }
                    else
                    {
                        row.GiamGiaPhanTram = 0;
                        row.GiamGiaTien = 0;
                        tienGiam = 0;
                    }

                    row.TongThanhToan = tongGoc - tienGiam;
                }

                rptHoaDon baoCao = new rptHoaDon();
                baoCao.SetDataSource(ds);
                crystalReportViewer1.ReportSource = baoCao;
                crystalReportViewer1.Refresh();
            }
            catch (System.IO.FileNotFoundException)
            {
                // Bắt lỗi thiếu thư viện Crystal Report
                MessageBox.Show("Tính năng này cần Crystal Report!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (System.IO.FileLoadException)
            {
                // Bắt lỗi không thể load thư viện Crystal Report
                MessageBox.Show("Tính năng này cần Crystal Report!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        #endregion
    }
}