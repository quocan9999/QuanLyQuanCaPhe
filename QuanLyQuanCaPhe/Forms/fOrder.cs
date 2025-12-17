using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class fOrder : Form
    {
        private int idBan;
        private List<MonOrderTam> danhSachMonTam = new List<MonOrderTam>();

        public fOrder(int idBanNhanVao)
        {
            InitializeComponent();
            this.idBan = idBanNhanVao;
        }
        #region Phương thức (hàm)
        // hàm tải danh sách danh mục và sản phẩm lên giao diện
        private void TaiDanhSachThucDon()
        {
            tabMenu.TabPages.Clear();
            string queryDanhMuc = "SELECT * FROM DanhMuc";
            DataTable bangDanhMuc = DataProvider.Instance.ExecuteQuery(queryDanhMuc);

            foreach (DataRow dongDanhMuc in bangDanhMuc.Rows)
            {
                int idDanhMuc = (int)dongDanhMuc["Id"];
                string tenDanhMuc = dongDanhMuc["TenDanhMuc"].ToString();

                // tạo tab page mới cho từng danh mục
                TabPage tab = new TabPage(tenDanhMuc);
                tab.Tag = idDanhMuc;

                // tạo layout panel để chứa các nút món ăn
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;
                flp.BackColor = Color.WhiteSmoke;
                flp.Padding = new Padding(10);

                // lấy danh sách sản phẩm thuộc danh mục này và còn bán
                string querySanPham = "SELECT * FROM SanPham WHERE MaDanhMuc = " + idDanhMuc + " AND TrangThai = N'Còn bán'";
                DataTable bangSanPham = DataProvider.Instance.ExecuteQuery(querySanPham);

                foreach (DataRow dongSanPham in bangSanPham.Rows)
                {
                    // tạo nút món ăn
                    Button nutMonAn = new Button();
                    nutMonAn.Size = new Size(150, 100);
                    nutMonAn.Margin = new Padding(10);
                    nutMonAn.BackColor = Color.LightCyan;
                    nutMonAn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

                    string tenMon = dongSanPham["TenSP"].ToString();
                    decimal donGia = Convert.ToDecimal(dongSanPham["DonGia"]);
                    nutMonAn.Text = tenMon + "\n" + donGia.ToString("N0") + "đ";

                    // lưu thông tin món vào tag của nút để dùng khi click
                    nutMonAn.Tag = new MonOrderTam
                    {
                        IdSanPham = (int)dongSanPham["Id"],
                        TenSP = tenMon,
                        DonGia = donGia,
                        TrangThai = dongSanPham["TrangThai"].ToString()
                    };

                    nutMonAn.Click += NutMonAn_Click;
                    flp.Controls.Add(nutMonAn);
                }

                tab.Controls.Add(flp);
                tabMenu.TabPages.Add(tab);
            }
        }

        // hàm hiển thị danh sách order lên dgv
        private void HienThiDanhSachOrder()
        {
            dgvOrderTemp.Rows.Clear();
            foreach (var item in danhSachMonTam)
            {
                int index = dgvOrderTemp.Rows.Add();
                dgvOrderTemp.Rows[index].Cells[0].Value = item.IdSanPham;
                dgvOrderTemp.Rows[index].Cells[1].Value = item.TenSP;
                dgvOrderTemp.Rows[index].Cells[2].Value = item.DonGia.ToString("N0");
                dgvOrderTemp.Rows[index].Cells[3].Value = item.SoLuong;
                dgvOrderTemp.Rows[index].Cells[4].Value = (item.SoLuong * item.DonGia).ToString("N0");
                dgvOrderTemp.Rows[index].Tag = item;
            }
        }
        #endregion

        #region Event
        private void fOrder_Load(object sender, EventArgs e)
        {
            TaiDanhSachThucDon();
        }

        private void NutMonAn_Click(object sender, EventArgs e)
        {
            Button nutBam = sender as Button;
            MonOrderTam monDuocChon = nutBam.Tag as MonOrderTam;

            if (monDuocChon == null) return;

            // kiểm tra xem món này đã có trong danh sách tạm chưa
            var monDaCo = danhSachMonTam.FirstOrDefault(x => x.IdSanPham == monDuocChon.IdSanPham);

            if (monDaCo != null)
            {
                // nếu có rồi thì tăng số lượng
                monDaCo.SoLuong++;
            }
            else
            {
                // nếu chưa có thì thêm mới vào danh sách
                danhSachMonTam.Add(new MonOrderTam
                {
                    IdSanPham = monDuocChon.IdSanPham,
                    TenSP = monDuocChon.TenSP,
                    DonGia = monDuocChon.DonGia,
                    SoLuong = 1,
                    TrangThai = monDuocChon.TrangThai
                });
            }

            HienThiDanhSachOrder();
        }

        private void dgvOrderTemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrderTemp.CurrentRow != null)
            {
                var item = dgvOrderTemp.CurrentRow.Tag as MonOrderTam;
                if (item != null)
                {
                    txtTenSP.Text = item.TenSP;
                    txtDonGia.Text = item.DonGia.ToString("N0");
                    txtTrangThai.Text = item.TrangThai;
                    nudSoLuong.Value = item.SoLuong;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvOrderTemp.CurrentRow == null) return;
            var item = dgvOrderTemp.CurrentRow.Tag as MonOrderTam;
            if (item != null)
            {
                item.SoLuong = (int)nudSoLuong.Value;
                HienThiDanhSachOrder();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvOrderTemp.CurrentRow == null) return;
            var item = dgvOrderTemp.CurrentRow.Tag as MonOrderTam;
            if (item != null)
            {
                danhSachMonTam.Remove(item);
                HienThiDanhSachOrder();
                txtTenSP.Clear();
                txtDonGia.Clear();
                txtTrangThai.Clear();
                nudSoLuong.Value = 1;
            }
        }

        private void btnXacNhanOrder_Click(object sender, EventArgs e)
        {
            if (danhSachMonTam.Count == 0)
            {
                MessageBox.Show("chưa chọn món nào!", "thông báo");
                return;
            }

            try
            {
                // lấy id hóa đơn chưa thanh toán của bàn hiện tại
                string truyVanLayIdHoaDon = "SELECT Id FROM HoaDon WHERE MaBan = " + idBan + " AND TrangThai = N'Chưa thanh toán'";
                object ketQuaId = DataProvider.Instance.ExecuteScalar(truyVanLayIdHoaDon);

                if (ketQuaId == null)
                {
                    MessageBox.Show("bàn này chưa được mở! vui lòng mở bàn trước khi gọi món.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idHoaDon = Convert.ToInt32(ketQuaId);

                // duyệt danh sách món tạm và lưu vào bảng ChiTietHoaDon
                foreach (var item in danhSachMonTam)
                {
                    // kiểm tra xem món này đã có trong chi tiết hóa đơn chưa
                    string truyVanKiemTraTonTai = "SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = " + idHoaDon + " AND MaSP = " + item.IdSanPham;
                    int soLuongTonTai = (int)DataProvider.Instance.ExecuteScalar(truyVanKiemTraTonTai);

                    if (soLuongTonTai > 0)
                    {
                        // nếu đã có thì cập nhật số lượng cộng thêm
                        string truyVanCapNhat = "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + " + item.SoLuong +
                                                " WHERE MaHoaDon = " + idHoaDon + " AND MaSP = " + item.IdSanPham;
                        DataProvider.Instance.ExecuteNonQuery(truyVanCapNhat);
                    }
                    else
                    {
                        // nếu chưa có thì thêm mới vào chi tiết hóa đơn
                        string truyVanThemMoi = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSP, SoLuong, DonGia) VALUES (" +
                                                idHoaDon + ", " + item.IdSanPham + ", " + item.SoLuong + ", " + item.DonGia + ")";
                        DataProvider.Instance.ExecuteNonQuery(truyVanThemMoi);
                    }
                }

                MessageBox.Show("gọi món thành công!", "thông báo");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("có lỗi xảy ra khi gọi món: " + ex.Message, "lỗi");
            }
        }


        #endregion

        public class MonOrderTam
        {
            public int IdSanPham { get; set; }
            public string TenSP { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public string TrangThai { get; set; }
        }
    }
}