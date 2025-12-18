# ☕ Hệ Thống Quản Lý Quán Cà Phê

<div align="center">

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red?style=for-the-badge&logo=microsoftsqlserver)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-blue?style=for-the-badge&logo=windows)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Ứng dụng quản lý quán cà phê hoàn chỉnh được xây dựng bằng C# Windows Forms và SQL Server**

[Tính năng](#-tính-năng-chính) • [Cài đặt](#-hướng-dẫn-cài-đặt) • [Cấu hình](#%EF%B8%8F-cấu-hình-connection-string) • [Sử dụng](#-hướng-dẫn-sử-dụng) • [Cấu trúc](#-cấu-trúc-project)

</div>

---

## 📋 Giới thiệu

Hệ thống Quản Lý Quán Cà Phê là một ứng dụng desktop được phát triển nhằm hỗ trợ quản lý các hoạt động kinh doanh của quán cà phê một cách hiệu quả. Ứng dụng cung cấp đầy đủ các chức năng từ quản lý order, thanh toán, quản lý sản phẩm đến báo cáo doanh thu.

## ✨ Tính năng chính

| Tính năng | Mô tả |
|-----------|-------|
| 🔐 **Đăng nhập/Phân quyền** | Hệ thống xác thực với phân quyền Admin/Nhân viên |
| 🍵 **Quản lý sản phẩm** | Thêm, sửa, xóa các món đồ uống và thức ăn |
| 📂 **Quản lý danh mục** | Phân loại sản phẩm theo danh mục |
| 🪑 **Quản lý bàn** | Quản lý trạng thái các bàn trong quán |
| 📝 **Đặt món (Order)** | Tạo order cho từng bàn, thêm/xóa món |
| 🔄 **Chuyển bàn** | Hỗ trợ chuyển order giữa các bàn |
| 💰 **Thanh toán** | Xử lý thanh toán với hỗ trợ giảm giá |
| 🧾 **In hóa đơn** | Xuất hóa đơn bằng Crystal Reports |
| 📊 **Báo cáo doanh thu** | Thống kê doanh thu theo thời gian |
| 🏆 **Báo cáo bán chạy** | Xem các sản phẩm bán chạy nhất |
| 👥 **Quản lý tài khoản** | Quản lý tài khoản người dùng hệ thống |

## 🛠️ Yêu cầu hệ thống

- **Hệ điều hành:** Windows 10/11
- **Framework:** .NET Framework 4.8
- **Database:** SQL Server 2019 trở lên (hoặc SQL Server Express)
- **IDE:** Visual Studio 2019/2022 (khuyến nghị)
- **Công cụ:** SQL Server Management Studio (SSMS)

## 📥 Hướng dẫn cài đặt

### Bước 1: Clone Repository

```bash
git clone https://github.com/quocan9999/QuanLyQuanCaPhe.git
cd QuanLyQuanCaPhe
```

### Bước 2: Tạo Database

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối đến SQL Server của bạn
3. Mở file `QuanLyQuanCaPhe/Database/QuanLyCaPhe_data.sql`
4. Thực thi script để tạo database và dữ liệu mẫu

```sql
-- Chạy script trong SSMS
-- File: QuanLyQuanCaPhe/Database/QuanLyCaPhe_data.sql
```

### Bước 3: Cấu hình Connection String

> ⚠️ **QUAN TRỌNG:** Đây là bước bắt buộc nếu ứng dụng báo lỗi kết nối database!

Chi tiết xem phần [Cấu hình Connection String](#%EF%B8%8F-cấu-hình-connection-string) bên dưới.

### Bước 4: Build và chạy ứng dụng

1. Mở file `QuanLyQuanCaPhe.sln` bằng Visual Studio
2. Nhấn `Ctrl + Shift + B` để build project
3. Nhấn `F5` hoặc `Ctrl + F5` để chạy ứng dụng

---

## ⚙️ Cấu hình Connection String

### 🔍 Xác định tên Server SQL của bạn

1. Mở **SQL Server Management Studio (SSMS)**
2. Trong cửa sổ **Connect to Server**, ghi nhớ giá trị **Server name**

   ![SSMS Connection](https://i.imgur.com/example.png)

   Ví dụ các giá trị thường gặp:
   - `.` hoặc `localhost` → SQL Server mặc định
   - `.\SQLEXPRESS` → SQL Server Express
   - `(localdb)\MSSQLLocalDB` → LocalDB
   - `DESKTOP-XXXXX\SQLEXPRESS` → Tên máy cụ thể

### 📝 Cập nhật Connection String

Mở file `QuanLyQuanCaPhe/DataProvider.cs`, tìm đến **dòng 21** và cập nhật:

```csharp
// Dòng 21 trong DataProvider.cs
private DataProvider()
{
    // ĐỔI GIÁ TRỊ "Data Source" THEO SERVER CỦA BẠN
    connectionString = @"Data Source = [TÊN_SERVER]; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True";
}
```

### 📌 Các ví dụ cụ thể

| Loại SQL Server | Connection String |
|-----------------|-------------------|
| **SQL Server mặc định** | `Data Source = .; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True` |
| **SQL Server Express** | `Data Source = .\SQLEXPRESS; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True` |
| **LocalDB** | `Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True` |
| **Tên máy cụ thể** | `Data Source = DESKTOP-ABC123\SQLEXPRESS; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True` |

### 🔧 Khắc phục lỗi kết nối thường gặp

<details>
<summary><b>❌ Lỗi: "A network-related or instance-specific error occurred..."</b></summary>

**Nguyên nhân:** Sai tên server hoặc SQL Server chưa chạy.

**Cách khắc phục:**
1. Kiểm tra SQL Server đang chạy:
   - Nhấn `Win + R` → gõ `services.msc` → Enter
   - Tìm **SQL Server (MSSQLSERVER)** hoặc **SQL Server (SQLEXPRESS)**
   - Đảm bảo trạng thái là **Running**

2. Kiểm tra tên server trong SSMS và cập nhật `DataProvider.cs`

</details>

<details>
<summary><b>❌ Lỗi: "Cannot open database 'QuanLyCaPhe'"</b></summary>

**Nguyên nhân:** Database chưa được tạo.

**Cách khắc phục:**
1. Mở SSMS, kết nối đến server
2. Chạy script `Database/QuanLyCaPhe_data.sql` để tạo database

</details>

<details>
<summary><b>❌ Lỗi: "Login failed for user..."</b></summary>

**Nguyên nhân:** Vấn đề xác thực.

**Cách khắc phục:**
- Đảm bảo sử dụng `Integrated Security = True` (Windows Authentication)
- Hoặc thêm `User ID` và `Password` nếu dùng SQL Authentication:
  ```csharp
  connectionString = @"Data Source = .; Initial Catalog = QuanLyCaPhe; User ID = sa; Password = 123456; TrustServerCertificate = True";
  ```

</details>

---

## 📖 Hướng dẫn sử dụng

### 🔐 Đăng nhập

Sử dụng tài khoản mặc định:
- **Tên đăng nhập:** `admin`
- **Mật khẩu:** `admin`

### 🖥️ Giao diện chính

Sau khi đăng nhập thành công, bạn sẽ thấy giao diện chính với:
- **Sidebar bên trái:** Menu các chức năng
- **Khu vực chính:** Hiển thị sơ đồ bàn của quán

### 📝 Quy trình đặt món

1. Click vào bàn trống (màu xanh) để mở form Order
2. Chọn món từ danh sách sản phẩm
3. Nhập số lượng và click "Thêm"
4. Khi khách thanh toán, click "Thanh toán"
5. Áp dụng giảm giá (nếu có) và xác nhận

### 📊 Xem báo cáo

- **Báo cáo doanh thu:** Menu → Báo cáo → Doanh thu
- **Món bán chạy:** Menu → Báo cáo → Bán chạy

---

## 📁 Cấu trúc Project

```
QuanLyQuanCaPhe/
├── 📂 Class/                    # Các class model
│   ├── Ban.cs                   # Model bàn
│   ├── DanhMuc.cs               # Model danh mục
│   ├── Mon.cs                   # Model sản phẩm
│   └── LuuTruThongTinDangNhap.cs # Lưu thông tin session
│
├── 📂 Database/                 # Scripts SQL
│   ├── QuanLyCaPhe_data.sql     # Script tạo DB + dữ liệu
│   ├── DuLieuMau.sql            # Dữ liệu mẫu
│   └── Procedure/               # Stored Procedures
│
├── 📂 Forms/                    # Các Windows Forms
│   ├── fDangNhap.cs             # Form đăng nhập
│   ├── fMain.cs                 # Form chính
│   ├── fOrder.cs                # Form đặt món
│   ├── fThanhToan.cs            # Form thanh toán
│   ├── fQuanLySanPham.cs        # Quản lý sản phẩm
│   ├── fQuanLyBan.cs            # Quản lý bàn
│   ├── fQuanLyDanhMuc.cs        # Quản lý danh mục
│   ├── fQuanLyTaiKhoan.cs       # Quản lý tài khoản
│   ├── fBaoCaoDoanhThu.cs       # Báo cáo doanh thu
│   ├── fBaoCaoBanChay.cs        # Báo cáo bán chạy
│   ├── fChuyenBan.cs            # Chuyển bàn
│   └── fInHoaDon.cs             # In hóa đơn
│
├── 📄 DataProvider.cs           # Singleton quản lý DB connection
├── 📄 Program.cs                # Entry point
├── 📄 rptHoaDon.rpt             # Crystal Report template
└── 📄 App.config                # Cấu hình ứng dụng
```

---

## 🗃️ Database Schema

### Các bảng chính

| Bảng | Mô tả |
|------|-------|
| `TaiKhoan` | Thông tin tài khoản người dùng |
| `DanhMuc` | Danh mục sản phẩm |
| `Mon` | Thông tin các món/sản phẩm |
| `Ban` | Thông tin các bàn |
| `HoaDon` | Hóa đơn bán hàng |
| `ChiTietHoaDon` | Chi tiết từng hóa đơn |

### Stored Procedures

| Procedure | Chức năng |
|-----------|-----------|
| `usp_Login` | Xác thực đăng nhập |
| `usp_InHoaDon` | Lấy dữ liệu in hóa đơn |
| `sp_ThanhToanDayDu` | Xử lý thanh toán |
| `sp_TinhTienBan` | Tính tiền cho bàn |

---

## 🤝 Đóng góp

Mọi đóng góp đều được hoan nghênh! Vui lòng:

1. Fork repository
2. Tạo branch mới (`git checkout -b feature/TinhNangMoi`)
3. Commit thay đổi (`git commit -m 'Thêm tính năng mới'`)
4. Push lên branch (`git push origin feature/TinhNangMoi`)
5. Tạo Pull Request

---

## 📝 License

Dự án này được phát hành dưới giấy phép [MIT License](LICENSE).

---

## 👥 Tác giả

- **Sinh viên:** Trường Đại học Công Thương TP.HCM (HUIT)
- **Môn học:** Công nghệ .NET
- **Học kỳ:** HK5 - 2024

---

<div align="center">

**⭐ Nếu project hữu ích, hãy cho một Star nhé! ⭐**

</div>