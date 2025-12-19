using CrystalDecisions.CrystalReports.Engine;
using QuanLyQuanCaPhe.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fInBaoCaoDoanhThu : Form
    {
        private DateTime tuNgay;
        private DateTime denNgay;
        private DataTable dtDoanhThu;

        public fInBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay, DataTable dtDoanhThu)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.dtDoanhThu = dtDoanhThu;
        }

        private void fInBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            TaiBaoCaoLenReport();
        }

        private void TaiBaoCaoLenReport()
        {
            try
            {
                dsBaoCaoDoanhThu ds = new dsBaoCaoDoanhThu();

                // Tính toán các thông tin tổng hợp
                decimal tongDoanhThu = 0;
                int tongSoHoaDon = 0;

                foreach (DataRow row in dtDoanhThu.Rows)
                {
                    dsBaoCaoDoanhThu.dtBaoCaoDoanhThuRow newRow = ds.dtBaoCaoDoanhThu.NewdtBaoCaoDoanhThuRow();

                    newRow.TuNgay = tuNgay;
                    newRow.DenNgay = denNgay;
                    newRow.Ngay = Convert.ToDateTime(row["Ngay"]);
                    newRow.SoHoaDon = Convert.ToInt32(row["SoHoaDon"]);
                    newRow.DoanhThu = Convert.ToDecimal(row["DoanhThu"]);

                    tongDoanhThu += newRow.DoanhThu;
                    tongSoHoaDon += newRow.SoHoaDon;

                    ds.dtBaoCaoDoanhThu.AdddtBaoCaoDoanhThuRow(newRow);
                }

                // Cập nhật thông tin tổng hợp cho tất cả các row
                foreach (dsBaoCaoDoanhThu.dtBaoCaoDoanhThuRow row in ds.dtBaoCaoDoanhThu.Rows)
                {
                    row.TongDoanhThu = tongDoanhThu;
                    row.SoHoaDonTong = tongSoHoaDon;
                    row.DoanhThuTrungBinh = tongSoHoaDon > 0 ? tongDoanhThu / tongSoHoaDon : 0;
                    row.NguoiLap = LuuTruThongTinDangNhap.HoTen;
                }

                if (ds.dtBaoCaoDoanhThu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo");
                    this.Close();
                    return;
                }

                rptBaoCaoDoanhThu baoCao = new rptBaoCaoDoanhThu();
                baoCao.SetDataSource(ds);
                crystalReportViewer1.ReportSource = baoCao;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi");
            }
        }
    }
}