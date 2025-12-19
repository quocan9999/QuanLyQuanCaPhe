using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fBaoCaoDoanhThu : Form
    {
        private DataProvider dataProvider;
        private int? currentUserId; // ID người dùng đang đăng nhập

        public fBaoCaoDoanhThu()
        {
            try
            {
                InitializeComponent();
                dataProvider = DataProvider.Instance;

                // Lấy ID người dùng hiện tại (bạn có thể truyền vào từ form login)
                currentUserId = GetCurrentUserId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message + "\n\n" + ex.StackTrace,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dataProvider đã được khởi tạo chưa
                if (dataProvider == null)
                {
                    MessageBox.Show("DataProvider chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra kết nối trước
                if (!dataProvider.TestConnection())
                {
                    MessageBox.Show("Không thể kết nối đến database.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thiết lập ngày mặc định (tháng hiện tại)
                dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpDenNgay.Value = DateTime.Now;

                // Load báo cáo mặc định
                LoadBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message + "\n\n" + ex.StackTrace,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy ID người dùng hiện tại (có thể lấy từ session hoặc biến toàn cục)
        // Lấy ID người dùng hiện tại từ thông tin đăng nhập
        private int? GetCurrentUserId()
        {
            try
            {
                // Lấy tên đăng nhập từ biến toàn cục đã lưu lúc login
                string tenDangNhap = LuuTruThongTinDangNhap.TenDangNhap;

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    return null;
                }

                // Truy vấn lấy id nhân viên từ tên đăng nhập
                string query = "SELECT Id FROM NhanVien WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", tenDangNhap)
                };

                object result = dataProvider.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin người dùng: " + ex.Message);
                return null;
            }
        }

        // Nút Xem Báo Cáo
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ngày hợp lệ
                if (dtpTuNgay.Value > dtpDenNgay.Value)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load báo cáo doanh thu theo khoảng thời gian
        private void LoadBaoCao()
        {
            try
            {
                string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
                string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd");

                // Query lấy doanh thu theo ngày
                string query = @"
  SELECT 
         CAST(hd.NgayLap AS DATE) AS Ngay,
         COUNT(DISTINCT hd.Id) AS SoHoaDon,
     SUM(hd.TongTien) AS DoanhThu
             FROM HoaDon hd
             WHERE hd.NgayLap >= @TuNgay 
AND hd.NgayLap <= @DenNgay
          AND hd.TrangThai = N'Đã thanh toán'
            GROUP BY CAST(hd.NgayLap AS DATE)
 ORDER BY Ngay";

                SqlParameter[] parameters = new SqlParameter[]
                {
         new SqlParameter("@TuNgay", tuNgay),
          new SqlParameter("@DenNgay", denNgay)
                };

                DataTable dt = dataProvider.ExecuteQuery(query, parameters);
                dgvDoanhThu.DataSource = dt;

                // Đặt tên cột tiếng Việt
                if (dgvDoanhThu.Columns.Count > 0)
                {
                    dgvDoanhThu.Columns["Ngay"].HeaderText = "Ngày";
                    dgvDoanhThu.Columns["SoHoaDon"].HeaderText = "Số Hóa Đơn";
                    dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh Thu (VNĐ)";

                    // Định dạng cột
                    dgvDoanhThu.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvDoanhThu.Columns["Ngay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvDoanhThu.Columns["SoHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDoanhThu.Columns["SoHoaDon"].DefaultCellStyle.Format = "N0";

                    dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                    dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tính toán thống kê
                CalculateStatistics(dt);

                // Vẽ biểu đồ
                DrawChart(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tính toán thống kê
        private void CalculateStatistics(DataTable dt)
        {
            try
            {
                decimal tongDoanhThu = 0;
                int tongSoHoaDon = 0;

                foreach (DataRow row in dt.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                    tongSoHoaDon += Convert.ToInt32(row["SoHoaDon"]);
                }

                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " đ";
                lblSoHoaDon.Text = tongSoHoaDon.ToString("N0");

                // Tính doanh thu trung bình
                int soNgay = dt.Rows.Count;
                decimal doanhThuTrungBinh = soNgay > 0 ? tongDoanhThu / soNgay : 0;
                lblDoanhThuTrungBinh.Text = doanhThuTrungBinh.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính toán thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Vẽ biểu đồ
        private void DrawChart(DataTable dt)
        {
            try
            {
                // Xóa dữ liệu cũ
                chartDoanhThu.Series.Clear();
                chartDoanhThu.ChartAreas.Clear();
                chartDoanhThu.Legends.Clear();
                chartDoanhThu.Titles.Clear();

                // Tạo ChartArea mới
                ChartArea chartArea = new ChartArea("ChartArea1");
                chartArea.AxisX.Title = "Ngày";
                chartArea.AxisY.Title = "Doanh Thu (VNĐ)";
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.LabelStyle.Angle = -45;
                chartArea.AxisX.LabelStyle.Format = "dd/MM";
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.AxisY.IsStartedFromZero = true;
                chartDoanhThu.ChartAreas.Add(chartArea);

                // Tạo Legend
                Legend legend = new Legend("Legend1");
                legend.Docking = Docking.Top;
                chartDoanhThu.Legends.Add(legend);

                // Tạo Series cho doanh thu
                Series seriesDoanhThu = new Series("Doanh thu");
                seriesDoanhThu.ChartType = SeriesChartType.Column;
                seriesDoanhThu.ChartArea = "ChartArea1";
                seriesDoanhThu.Legend = "Legend1";
                seriesDoanhThu.IsValueShownAsLabel = true;
                seriesDoanhThu.LabelFormat = "N0";
                seriesDoanhThu.Color = Color.DodgerBlue;

                // Thêm dữ liệu vào chart
                foreach (DataRow row in dt.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);

                    seriesDoanhThu.Points.AddXY(ngay.ToString("dd/MM"), doanhThu);
                }

                chartDoanhThu.Series.Add(seriesDoanhThu);

                // Tạo Series cho đường trung bình (tùy chọn)
                if (dt.Rows.Count > 0)
                {
                    decimal tongDoanhThu = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                    }
                    decimal trungBinh = tongDoanhThu / dt.Rows.Count;

                    Series seriesTrungBinh = new Series("Trung bình");
                    seriesTrungBinh.ChartType = SeriesChartType.Line;
                    seriesTrungBinh.ChartArea = "ChartArea1";
                    seriesTrungBinh.Legend = "Legend1";
                    seriesTrungBinh.Color = Color.Red;
                    seriesTrungBinh.BorderWidth = 2;
                    seriesTrungBinh.BorderDashStyle = ChartDashStyle.Dash;

                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                        seriesTrungBinh.Points.AddXY(ngay.ToString("dd/MM"), trungBinh);
                    }

                    chartDoanhThu.Series.Add(seriesTrungBinh);
                }

                // Thiết lập tiêu đề
                chartDoanhThu.Titles.Add("Biểu đồ doanh thu theo ngày");
                chartDoanhThu.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Tải lại dữ liệu
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBaoCao();
                MessageBox.Show("Đã tải lại dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xuất Excel
        //private void btnXuatExcel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dgvDoanhThu.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Tạo SaveFileDialog
        //        SaveFileDialog saveDialog = new SaveFileDialog();
        //        saveDialog.Filter = "Excel Files|*.xls;*.xlsx|CSV Files|*.csv|All Files|*.*";
        //        saveDialog.Title = "Lưu báo cáo";
        //        saveDialog.FileName = "BaoCao_DoanhThu_" +
        //        dtpTuNgay.Value.ToString("yyyyMMdd") + "_" +
        //        dtpDenNgay.Value.ToString("yyyyMMdd");

        //        if (saveDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            // Xuất ra file CSV (có thể mở bằng Excel)
        //            ExportToCSV(saveDialog.FileName);
        //            MessageBox.Show("Xuất báo cáo thành công!\nFile: " + saveDialog.FileName,
        //            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            // Mở file sau khi xuất
        //            if (MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Xác nhận",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                System.Diagnostics.Process.Start(saveDialog.FileName);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Xuất dữ liệu ra file CSV
        //private void ExportToCSV(string filePath)
        //{
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        // Thêm tiêu đề báo cáo
        //        sb.AppendLine("BÁO CÁO DOANH THU");
        //        sb.AppendLine("Từ ngày: " + dtpTuNgay.Value.ToString("dd/MM/yyyy") +
        //        " - Đến ngày: " + dtpDenNgay.Value.ToString("dd/MM/yyyy"));
        //        sb.AppendLine("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        //        sb.AppendLine("");

        //        // Thêm header
        //        for (int i = 0; i < dgvDoanhThu.Columns.Count; i++)
        //        {
        //            sb.Append(dgvDoanhThu.Columns[i].HeaderText);
        //            if (i < dgvDoanhThu.Columns.Count - 1)
        //                sb.Append(",");
        //        }
        //        sb.AppendLine();

        //        // Thêm dữ liệu
        //        foreach (DataGridViewRow row in dgvDoanhThu.Rows)
        //        {
        //            for (int i = 0; i < dgvDoanhThu.Columns.Count; i++)
        //            {
        //                if (row.Cells[i].Value != null)
        //                {
        //                    string value = row.Cells[i].Value.ToString();
        //                    // Xử lý giá trị có dấu phẩy
        //                    if (value.Contains(","))
        //                        value = "\"" + value + "\"";
        //                    sb.Append(value);
        //                }
        //                if (i < dgvDoanhThu.Columns.Count - 1)
        //                    sb.Append(",");
        //            }
        //            sb.AppendLine();
        //        }

        //        // Thêm thống kê
        //        sb.AppendLine("");
        //        sb.AppendLine("THỐNG KÊ TỔNG HỢP");
        //        sb.AppendLine("Tổng doanh thu," + lblTongDoanhThu.Text);
        //        sb.AppendLine("Số hóa đơn," + lblSoHoaDon.Text);
        //        sb.AppendLine("Doanh thu trung bình," + lblDoanhThuTrungBinh.Text);

        //        // Ghi file với encoding UTF-8 (có BOM để Excel đọc được tiếng Việt)
        //        System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi ghi file: " + ex.Message);
        //    }
        //}

        // Nút Lưu Báo Cáo vào database
        private void btnLuuBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDoanhThu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentUserId == null || currentUserId <= 0)
                {
                    MessageBox.Show("Không xác định được người lập báo cáo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tính tổng doanh thu
                decimal tongDoanhThu = 0;
                foreach (DataGridViewRow row in dgvDoanhThu.Rows)
                {
                    if (row.Cells["DoanhThu"].Value != null)
                    {
                        tongDoanhThu += Convert.ToDecimal(row.Cells["DoanhThu"].Value);
                    }
                }

                // Lưu vào bảng BaoCao_DoanhThu
                string query = @"INSERT INTO BaoCao_DoanhThu (TuNgay, DenNgay, TongDoanhThu, NguoiLap)
                               VALUES (@TuNgay, @DenNgay, @TongDoanhThu, @NguoiLap)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@TuNgay", dtpTuNgay.Value.Date),
                        new SqlParameter("@DenNgay", dtpDenNgay.Value.Date),
                        new SqlParameter("@TongDoanhThu", tongDoanhThu),
                        new SqlParameter("@NguoiLap", currentUserId.Value)
                };

                int result = dataProvider.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Lưu báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDoanhThu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = (DataTable)dgvDoanhThu.DataSource;

                fInBaoCaoDoanhThu formIn = new fInBaoCaoDoanhThu(
                    dtpTuNgay.Value.Date,
                    dtpDenNgay.Value.Date,
                    dt
                );
                formIn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
