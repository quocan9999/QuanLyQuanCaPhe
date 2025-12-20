# ☕ Hệ Thống Quản Lý Quán Cà Phê

<div align="center">

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2012+-red?style=for-the-badge&logo=microsoftsqlserver)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-blue?style=for-the-badge&logo=windows)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Ứng dụng quản lý quán cà phê hoàn chỉnh được xây dựng bằng C# Windows Forms và SQL Server**

[Tính năng](#-tính-năng-chính) • [Cài đặt](#-hướng-dẫn-cài-đặt) • [Cấu hình](#%EF%B8%8F-cấu-hình-connection-string) • [AI Chatbot](#-cấu-hình-gemini-api-key-chatbot-ai) • [Sử dụng](#-hướng-dẫn-sử-dụng) • [Cấu trúc](#-cấu-trúc-project)

</div>

---

## 📋 Giới thiệu

Hệ thống Quản Lý Quán Cà Phê là một ứng dụng desktop được phát triển nhằm hỗ trợ quản lý các hoạt động kinh doanh của quán cà phê một cách hiệu quả. Ứng dụng cung cấp đầy đủ các chức năng từ quản lý order, thanh toán, quản lý sản phẩm đến báo cáo doanh thu.

## ✨ Tính năng chính

### 🔐 Xác thực & Phân quyền
| Tính năng | Mô tả |
|-----------|-------|
| **Đăng nhập** | Xác thực người dùng với mã hóa mật khẩu |
| **Phân quyền** | Phân quyền Admin/Nhân viên với các chức năng riêng biệt |
| **Xem thông tin cá nhân** | Nhân viên xem được thông tin hồ sơ của mình |

### 🛒 Nghiệp vụ bán hàng
| Tính năng | Mô tả |
|-----------|-------|
| **Đặt món (Order)** | Tạo order cho từng bàn, thêm/xóa/sửa số lượng món |
| **Chuyển bàn** | Hỗ trợ chuyển order giữa các bàn |
| **Thanh toán** | Xử lý thanh toán với hỗ trợ giảm giá theo % hoặc tiền mặt |
| **In hóa đơn** | Xuất hóa đơn tạm bằng Crystal Reports |

### 📦 Quản lý dữ liệu (Admin)
| Tính năng | Mô tả |
|-----------|-------|
| **Quản lý sản phẩm** | Thêm, sửa, xóa sản phẩm với trạng thái còn bán/tạm ngưng |
| **Quản lý danh mục** | Phân loại sản phẩm theo danh mục |
| **Quản lý bàn** | Quản lý thông tin và vị trí các bàn trong quán |
| **Quản lý nhân viên** | Xem và cập nhật thông tin nhân viên |
| **Quản lý tài khoản** | Thêm, sửa, khóa/mở khóa tài khoản người dùng |

### 📊 Báo cáo & Thống kê (Admin)
| Tính năng | Mô tả |
|-----------|-------|
| **Báo cáo doanh thu** | Thống kê doanh thu theo khoảng thời gian, xuất báo cáo Crystal Reports |
| **Báo cáo bán chạy** | Xem top 10 sản phẩm bán chạy nhất |

### 🤖 Trợ lý AI gợi ý món (Gemini API)
| Tính năng | Mô tả |
|-----------|-------|
| **Chat AI gợi ý món** | Trợ lý AI hỗ trợ nhân viên tư vấn món cho khách hàng |
| **Gợi ý theo bối cảnh** | AI phân tích và đề xuất món phù hợp với tình huống |
| **Món bán chạy nhất** | AI tổng hợp và gợi ý các món được yêu thích |
| **Món lợi nhuận cao** | Gợi ý món có doanh thu cao cho quán |
| **Món theo thời gian** | Đề xuất món phù hợp theo buổi sáng/trưa/chiều/tối |

### ⚙️ Tính năng tự động (Database Trigger)
| Tính năng | Mô tả |
|-----------|-------|
| **Tự động tạo hồ sơ nhân viên** | Khi tạo tài khoản mới, hệ thống tự động tạo hồ sơ nhân viên |
| **Đồng bộ trạng thái** | Khi khóa/mở tài khoản, trạng thái nhân viên được cập nhật tương ứng |
| **Cập nhật trạng thái bàn** | Tự động chuyển trạng thái bàn khi có order/thanh toán |

## 🛠️ Yêu cầu hệ thống

- **Hệ điều hành:** Windows 10/11
- **Framework:** .NET Framework 4.8
- **Database:** SQL Server 2012+
- **IDE:** Visual Studio 2019/2022 (khuyến nghị)
- **Công cụ:** SQL Server Management Studio (SSMS)
- **Reporting Tool:** Crystal Reports (cần thiết cho chức năng báo cáo và in hóa đơn)

## 📥 Hướng dẫn cài đặt

### Bước 1: Clone Repository

```bash
git clone https://github.com/quocan9999/QuanLyQuanCaPhe.git
cd QuanLyQuanCaPhe
```

### Bước 2: Restore Database từ file Backup

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối đến SQL Server của bạn
3. **Chuột phải** vào **Databases** trong Object Explorer
4. Chọn **Restore Database...**

5. **Trong cửa sổ Restore Database:**
   - Chọn **Device** → Click nút **`...`** (Browse)
   - Click **Add** → Điều hướng đến thư mục project → `QuanLyQuanCaPhe/Database/`
   - Chọn file **`QuanLyCaPhe.bak`** → Click **OK**
   - Click **OK** lần nữa để quay lại cửa sổ Restore Database

6. **Kiểm tra thông tin:**
   - **Database:** Sẽ tự động điền `QuanLyCaPhe`
   - **Destination → Database:** `QuanLyCaPhe`

7. Click **OK** để bắt đầu restore

8. Đợi thông báo **"Database 'QuanLyCaPhe' restored successfully"** → Click **OK**

> 💡 **Mẹo:** Nếu gặp lỗi "tail of the log backup", vào **Options** bên trái và check **"Overwrite the existing database"**

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

   ![SSMS Connection](QuanLyQuanCaPhe\HinhAnh\servername.png)

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

**Nguyên nhân:** Database chưa được restore.

**Cách khắc phục:**
1. Mở SSMS, kết nối đến server
2. Restore database từ file `Database/QuanLyCaPhe.bak` (xem Bước 2 ở trên)

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

## 🤖 Cấu hình Gemini API Key (Chatbot AI)

> ⚠️ **QUAN TRỌNG:** Để sử dụng tính năng **Trợ lý AI gợi ý món**, bạn cần có API Key của Google Gemini.

### 🔑 Bước 1: Lấy API Key miễn phí

1. Truy cập **Google AI Studio**: [https://makersuite.google.com/app/apikey](https://makersuite.google.com/app/apikey)
2. Đăng nhập bằng tài khoản Google
3. Click **"Create API Key"** để tạo key mới
4. **Copy API Key** đã được tạo (dạng `AIzaSy...`)

> 💡 **Lưu ý:** API Key miễn phí có giới hạn 60 requests/phút, đủ dùng cho mục đích học tập.

### 📝 Bước 2: Cập nhật API Key vào Project

Mở file `QuanLyQuanCaPhe/Class/AIService.cs`, tìm đến **dòng 19** và thay thế:

```csharp
// Dòng 19 trong AIService.cs
// TRƯỚC:
private const string GEMINI_API_KEY = "YOUR_API_KEY";

// SAU: (thay bằng API key thực của bạn)
private const string GEMINI_API_KEY = "AIzaSyxxxxxxxxxxxxxxxxxxxxxxxxxx";
```

### ✅ Bước 3: Kiểm tra kết nối

1. Build và chạy ứng dụng
2. Đăng nhập vào hệ thống
3. Tại giao diện chính, tìm giao diện **"Trợ lý AI"**
4. Thử gửi tin nhắn để kiểm tra AI phản hồi

### 🔧 Khắc phục lỗi thường gặp

<details>
<summary><b>❌ Lỗi: "Lỗi API (HTTP 400)" hoặc "API key not valid"</b></summary>

**Nguyên nhân:** API Key không hợp lệ hoặc chưa được kích hoạt.

**Cách khắc phục:**
1. Kiểm tra lại API Key đã copy đúng chưa (không có khoảng trắng thừa)
2. Đảm bảo đã **Enable Generative Language API** trong [Google Cloud Console](https://console.cloud.google.com/)
3. Tạo API Key mới nếu vẫn lỗi

</details>

<details>
<summary><b>❌ Lỗi: "Lỗi kết nối mạng"</b></summary>

**Nguyên nhân:** Không có kết nối internet hoặc bị chặn.

**Cách khắc phục:**
1. Kiểm tra kết nối internet
2. Tắt VPN/Proxy nếu đang sử dụng
3. Kiểm tra Firewall không chặn ứng dụng

</details>

<details>
<summary><b>❌ Lỗi: "Exceeded quota" (Vượt hạn mức)</b></summary>

**Nguyên nhân:** Đã vượt quá 60 requests/phút của gói miễn phí.

**Cách khắc phục:**
1. Đợi 1 phút và thử lại
2. Hạn chế số lần gửi tin nhắn
3. Nâng cấp lên gói trả phí nếu cần sử dụng nhiều

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
├── 📂 Class/                    # Các class model và service
│   ├── AIService.cs             # Service gọi Gemini API cho AI gợi ý món
│   ├── Ban.cs                   # Model bàn
│   ├── DanhMuc.cs               # Model danh mục
│   ├── SanPham.cs               # Model sản phẩm
│   ├── NguoiDung.cs             # Model người dùng/tài khoản
│   ├── NhanVien.cs              # Model nhân viên
│   └── LuuTruThongTinDangNhap.cs # Lưu thông tin session đăng nhập
│
├── 📂 Database/                 # Database Backup
│   └── QuanLyCaPhe.bak          # File backup database (restore để sử dụng)
│
├── 📂 Lib/                      # Thư viện DLLs cần thiết cho Crystal Report
│
├── 📂 Forms/                    # Các Windows Forms
│   ├── fDangNhap.cs             # Form đăng nhập
│   ├── fMain.cs                 # Form chính (có tích hợp AI Chat)
│   ├── fOrder.cs                # Form đặt món
│   ├── fThanhToan.cs            # Form thanh toán
│   ├── fChuyenBan.cs            # Form chuyển bàn
│   ├── fInHoaDon.cs             # Form in hóa đơn tạm
│   ├── fQuanLySanPham.cs        # Quản lý sản phẩm
│   ├── fQuanLyDanhMuc.cs        # Quản lý danh mục
│   ├── fQuanLyBan.cs            # Quản lý bàn
│   ├── fQuanLyNhanVien.cs       # Quản lý nhân viên
│   ├── fQuanLyTaiKhoan.cs       # Quản lý tài khoản
│   ├── fThongTinCaNhan.cs       # Xem thông tin cá nhân
│   ├── fBaoCaoDoanhThu.cs       # Báo cáo doanh thu
│   ├── fBaoCaoBanChay.cs        # Báo cáo bán chạy
│   └── fInBaoCaoDoanhThu.cs     # In báo cáo doanh thu
│
├── 📄 DataProvider.cs           # Singleton quản lý DB connection
├── 📄 Program.cs                # Entry point
├── 📄 rptHoaDon.rpt             # Crystal Report - Hóa đơn
├── 📄 rptBaoCaoDoanhThu.rpt     # Crystal Report - Báo cáo doanh thu
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