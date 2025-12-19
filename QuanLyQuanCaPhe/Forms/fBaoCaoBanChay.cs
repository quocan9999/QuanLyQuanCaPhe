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
    public partial class fBaoCaoBanChay : Form
    {
        private DataProvider dataProvider;

        public fBaoCaoBanChay()
        {
            try
            {
                InitializeComponent();
                dataProvider = DataProvider.Instance;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message + "\n\n" + ex.StackTrace,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region TẢI DỮ LIỆU BÁO CÁO

        private void BaoCaoBanChay_Load(object sender, EventArgs e)
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

                LoadBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message + "\n\n" + ex.StackTrace,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load báo cáo món bán chạy
        private void LoadBaoCao()
        {
            try
            {
                string query = "SELECT * FROM v_BaoCao_MonBanChay";
                DataTable dt = dataProvider.ExecuteQuery(query);
                dgvBaoCao.DataSource = dt;

                // Đặt tên cột tiếng Việt
                if (dgvBaoCao.Columns.Count > 0)
                {
                    dgvBaoCao.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                    dgvBaoCao.Columns["TongSoLuong"].HeaderText = "Tổng Số Lượng Đã Bán";

                    // Căn giữa cột số lượng
                    dgvBaoCao.Columns["TongSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvBaoCao.Columns["TongSoLuong"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Định dạng số cho cột số lượng
                    dgvBaoCao.Columns["TongSoLuong"].DefaultCellStyle.Format = "N0";
                }

                // Tính toán thống kê
                CalculateStatistics(dt);

                // Thêm màu sắc cho các hàng (top 3 nổi bật)
                ColorizeTopRows();
 
                // Vẽ biểu đồ
                DrawChart(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

        #region THỐNG KÊ & HIỂN THỊ

        // Tính toán thống kê
        private void CalculateStatistics(DataTable dt)
        {
            try
            {
                int tongSoMon = dt.Rows.Count;
                int tongSoLuong = 0;

                foreach (DataRow row in dt.Rows)
                {
                    tongSoLuong += Convert.ToInt32(row["TongSoLuong"]);
                }

                lblTongSoMon.Text = tongSoMon.ToString();
                lblTongSoLuong.Text = tongSoLuong.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính toán thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô màu cho top 3 món bán chạy nhất
        private void ColorizeTopRows()
        {
            try
            {
                if (dgvBaoCao.Rows.Count > 0)
                {
                    // Top 1: Vàng đậm
                    dgvBaoCao.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgvBaoCao.Rows[0].DefaultCellStyle.Font = new Font(dgvBaoCao.Font, FontStyle.Bold);
                }

                if (dgvBaoCao.Rows.Count > 1)
                {
                    // Top 2: Bạc
                    dgvBaoCao.Rows[1].DefaultCellStyle.BackColor = Color.Silver;
                    dgvBaoCao.Rows[1].DefaultCellStyle.Font = new Font(dgvBaoCao.Font, FontStyle.Bold);
                }

                if (dgvBaoCao.Rows.Count > 2)
                {
                    // Top 3: Đồng
                    dgvBaoCao.Rows[2].DefaultCellStyle.BackColor = Color.SandyBrown;
                    dgvBaoCao.Rows[2].DefaultCellStyle.Font = new Font(dgvBaoCao.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                // Không cần hiển thị lỗi cho việc tô màu
            }
        }

        #endregion

        #region VẼ BIỂU ĐỒ

        // Vẽ biểu đồ
        private void DrawChart(DataTable dt)
        {
            try
            {
                // Xóa dữ liệu cũ
                chartBanChay.Series.Clear();
                chartBanChay.ChartAreas.Clear();
                chartBanChay.Legends.Clear();

                // Tạo ChartArea mới
                ChartArea chartArea = new ChartArea("ChartArea1");
                chartArea.AxisX.Title = "Tên Món";
                chartArea.AxisY.Title = "Số Lượng";
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.LabelStyle.Angle = -45; // Xoay label 45 độ
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartBanChay.ChartAreas.Add(chartArea);

                // Tạo Legend
                Legend legend = new Legend("Legend1");
                legend.Docking = Docking.Top;
                chartBanChay.Legends.Add(legend);

                // Tạo Series
                Series series = new Series("Số lượng bán");
                series.ChartType = SeriesChartType.Column;
                series.ChartArea = "ChartArea1";
                series.Legend = "Legend1";
                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                series.LabelFormat = "N0";

                // Thêm dữ liệu vào chart
                int index = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string tenSP = row["TenSP"].ToString();
                    int soLuong = Convert.ToInt32(row["TongSoLuong"]);
                
                    int pointIndex = series.Points.AddXY(tenSP, soLuong);
                
                    // Tô màu cho top 3
                    if (index == 0)
                        series.Points[pointIndex].Color = Color.Gold; // Top 1
                    else if (index == 1)
                        series.Points[pointIndex].Color = Color.Silver; // Top 2
                    else if (index == 2)
                        series.Points[pointIndex].Color = Color.SandyBrown; // Top 3
                    else
                        series.Points[pointIndex].Color = Color.SteelBlue; // Các món khác
                
                    index++;
                }

                chartBanChay.Series.Add(series);

                // Thiết lập tiêu đề
                chartBanChay.Titles.Clear();
                chartBanChay.Titles.Add("Biểu đồ món bán chạy");
                chartBanChay.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region XUẤT BÁO CÁO

        // Nút Xuất Excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBaoCao.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo SaveFileDialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
                saveDialog.Title = "Lưu báo cáo";
                saveDialog.FileName = "BaoCao_MonBanChay_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Xuất ra file CSV (có thể mở bằng Excel)
                    ExportToCSV(saveDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!\nFile: " + saveDialog.FileName,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file sau khi xuất
                    if (MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xuất dữ liệu ra file CSV
        private void ExportToCSV(string filePath)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Thêm tiêu đề báo cáo
                sb.AppendLine("BÁO CÁO TOP 10 MÓN BÁN CHẠY");
                sb.AppendLine("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                sb.AppendLine("" );

                // Thêm header
                for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                {
                    sb.Append(dgvBaoCao.Columns[i].HeaderText);
                    if (i < dgvBaoCao.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();

                // Thêm dữ liệu
                foreach (DataGridViewRow row in dgvBaoCao.Rows)
                {
                    for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            string value = row.Cells[i].Value.ToString();
                            // Xử lý giá trị có dấu phẩy
                            if (value.Contains(","))
                                value = "\"" + value + "\"";
                            sb.Append(value);
                        }
                        if (i < dgvBaoCao.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();
                }

                // Thêm thống kê
                sb.AppendLine("");
                sb.AppendLine("THỐNG KÊ");
                sb.AppendLine("Tổng số món bán chạy," + lblTongSoMon.Text);
                sb.AppendLine("Tổng số lượng đã bán," + lblTongSoLuong.Text);

                // Ghi file với encoding UTF-8 (có BOM để Excel đọc được tiếng Việt)
                System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi ghi file: " + ex.Message);
            }
        }

        #endregion
    }
}
