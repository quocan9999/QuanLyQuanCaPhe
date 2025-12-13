# ?? BÁO CÁO DOANH THU - T?NG QUAN

## ? Gi?i Thi?u
Form **BaoCaoDoanhThu** là m?t công c? báo cáo doanh thu chuyên nghi?p ???c thi?t k? cho h? th?ng qu?n lý quán cà phê. Form cung c?p giao di?n tr?c quan v?i bi?u ??, b?ng d? li?u và các ch? s? th?ng kê quan tr?ng.

## ?? Tính N?ng Chính

### 1. L?c Theo Kho?ng Th?i Gian
- DateTimePicker cho phép ch?n ngày b?t ??u và k?t thúc
- Validation ??m b?o ngày h?p l?
- M?c ??nh hi?n th? d? li?u tháng hi?n t?i

### 2. Hi?n Th? D? Li?u
- **DataGridView**: 
  - Hi?n th? doanh thu theo t?ng ngày
  - ??nh d?ng s? ti?n v?i d?u phân cách hàng nghìn
  - Ch? ?? ch? ??c, không cho phép ch?nh s?a

### 3. Bi?u ?? Tr?c Quan
- **Bi?u ?? c?t (Column Chart)**: 
  - Hi?n th? doanh thu t?ng ngày
  - Màu xanh d??ng (DodgerBlue)
  - Hi?n th? giá tr? trên m?i c?t
  
- **???ng trung bình (Line Chart)**:
  - ???ng nét ??t màu ??
  - Hi?n th? doanh thu trung bình
  - Giúp so sánh các ngày v?i m?c trung bình

### 4. Th?ng Kê T? ??ng
- **T?ng doanh thu**: T?ng c?ng doanh thu trong kho?ng th?i gian
- **S? hóa ??n**: T?ng s? hóa ??n ?ã thanh toán
- **Doanh thu trung bình**: Doanh thu trung bình m?i ngày

### 5. Xu?t Báo Cáo
- Xu?t ra file CSV (Excel-compatible)
- Encoding UTF-8 h? tr? ti?ng Vi?t
- Bao g?m header, data và th?ng kê
- Tùy ch?n m? file ngay sau khi xu?t

### 6. L?u Báo Cáo Vào Database
- L?u thông tin báo cáo vào b?ng `BaoCao_DoanhThu`
- Ghi nh?n ng??i l?p báo cáo
- H? tr? tra c?u l?ch s? báo cáo

## ??? Ki?n Trúc

### Components
```
BaoCaoDoanhThu (Form)
??? GroupBox: L?c d? li?u
?   ??? DateTimePicker: T? ngày
?   ??? DateTimePicker: ??n ngày
?   ??? Button: Xem Báo Cáo
??? DataGridView: B?ng d? li?u
??? Chart: Bi?u ?? doanh thu
??? GroupBox: Th?ng kê
?   ??? Label: T?ng doanh thu
?   ??? Label: S? hóa ??n
?   ??? Label: Doanh thu trung bình
??? GroupBox: Ch?c n?ng
    ??? Button: T?i l?i
  ??? Button: Xu?t Excel
    ??? Button: L?u Báo Cáo
```

### Database Schema
```sql
-- B?ng chính
BaoCao_DoanhThu
??? Id (INT, PK, IDENTITY)
??? TuNgay (DATE)
??? DenNgay (DATE)
??? TongDoanhThu (DECIMAL(18,2))
??? NguoiLap (INT, FK -> NhanVien.Id)

-- D? li?u ngu?n
HoaDon
??? Id
??? NgayLap
??? TongTien
??? TrangThai
```

## ?? Flow Chart

```
[Start]
   ?
[Ch?n kho?ng th?i gian]
   ?
[Nh?n "Xem Báo Cáo"]
   ?
[Validate ngày] ? [N?u l?i] ? [Hi?n th? thông báo]
   ?
[Query database]
   ?
[Tính toán th?ng kê]
   ?
[Hi?n th? DataGridView]
   ?
[V? bi?u ??]
   ?
[Hi?n th? k?t qu?]
   ?
[Ch?n hành ??ng]
   ??? [T?i l?i] ? [Quay l?i Query database]
   ??? [Xu?t Excel] ? [T?o file CSV] ? [L?u file]
   ??? [L?u Báo Cáo] ? [Insert vào DB] ? [Thông báo]
```

## ?? SQL Scripts

### 1. Views
- `v_BaoCao_DoanhThuTheoNgay`: Doanh thu theo ngày
- `v_BaoCao_DoanhThuTheoThang`: Doanh thu theo tháng
- `v_LichSuBaoCaoDoanhThu`: L?ch s? báo cáo
- `v_ThongKeBaoCaoTheoNhanVien`: Th?ng kê theo nhân viên

### 2. Stored Procedures
- `sp_GetBaoCaoDoanhThu`: L?y d? li?u báo cáo
- `sp_LuuBaoCaoDoanhThu`: L?u báo cáo m?i

## ?? UI/UX Design

### Color Scheme
| Element | Color | Hex Code |
|---------|-------|----------|
| Tiêu ?? | Dark Blue | #00008B |
| Nút chính | Dodger Blue | #1E90FF |
| Nút l?u | Medium Sea Green | #3CB371 |
| T?ng doanh thu | Green | #008000 |
| S? hóa ??n | Blue | #0000FF |
| Trung bình | Dark Orange | #FF8C00 |
| Chart - C?t | Dodger Blue | #1E90FF |
| Chart - ???ng | Red | #FF0000 |

### Layout
- **Form Size**: 984 x 641 pixels
- **Position**: Center Screen
- **Border Style**: Fixed Dialog
- **Maximize**: Disabled

## ?? Cài ??t & S? D?ng

### Prerequisites
1. .NET Framework 4.8
2. SQL Server (Express ho?c cao h?n)
3. Visual Studio 2019 ho?c m?i h?n

### B??c 1: Setup Database
```sql
-- Ch?y script t?o b?ng
CREATE TABLE BaoCao_DoanhThu (
 Id INT IDENTITY(1,1) PRIMARY KEY,
    TuNgay DATE,
    DenNgay DATE,
    TongDoanhThu DECIMAL(18,2),
    NguoiLap INT FOREIGN KEY REFERENCES NhanVien(Id),
    CHECK (DenNgay >= TuNgay)
);

-- Ch?y script t?o views và stored procedures
Execute: QuanLyQuanCaPhe\SQL\Create_View_BaoCaoDoanhThu.sql
```

### B??c 2: M? Form T? Code
```csharp
// T? menu ho?c button khác
BaoCaoDoanhThu formBaoCao = new BaoCaoDoanhThu();
formBaoCao.ShowDialog();
```

### B??c 3: S? D?ng
1. Form t? ??ng load d? li?u tháng hi?n t?i
2. Thay ??i kho?ng th?i gian n?u c?n
3. Nh?n "Xem Báo Cáo" ?? c?p nh?t
4. Phân tích d? li?u qua b?ng và bi?u ??
5. Xu?t Excel ho?c L?u báo cáo n?u c?n

## ?? Ví D? S? D?ng

### Case 1: Xem Doanh Thu Tháng Hi?n T?i
```csharp
// Form t? ??ng hi?n th? d? li?u tháng hi?n t?i khi load
// Không c?n code thêm
```

### Case 2: Xem Doanh Thu Tháng Tr??c
```csharp
dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
dtpDenNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
btnXemBaoCao.PerformClick();
```

### Case 3: Xu?t Báo Cáo Ra File
```csharp
// User click vào nút "Xu?t Excel"
// System t? ??ng:
// 1. Ki?m tra d? li?u
// 2. M? SaveFileDialog
// 3. T?o file CSV
// 4. H?i có mu?n m? file không
```

### Case 4: L?u Báo Cáo Vào DB
```csharp
// User click vào nút "L?u Báo Cáo"
// System t? ??ng:
// 1. Ki?m tra d? li?u
// 2. L?y ID ng??i dùng
// 3. Tính t?ng doanh thu
// 4. Insert vào BaoCao_DoanhThu
// 5. Hi?n th? k?t qu?
```

## ?? Query Samples

### L?y Doanh Thu Theo Ngày
```sql
SELECT 
    CAST(hd.NgayLap AS DATE) AS Ngay,
    COUNT(DISTINCT hd.Id) AS SoHoaDon,
    SUM(hd.TongTien) AS DoanhThu
FROM HoaDon hd
WHERE hd.NgayLap >= '2024-01-01' 
  AND hd.NgayLap <= '2024-01-31'
  AND hd.TrangThai = N'?ã thanh toán'
GROUP BY CAST(hd.NgayLap AS DATE)
ORDER BY Ngay;
```

### Xem L?ch S? Báo Cáo
```sql
SELECT * FROM v_LichSuBaoCaoDoanhThu
ORDER BY TuNgay DESC;
```

## ? Performance Tips

1. **Index trên NgayLap**: T?ng t?c query theo ngày
```sql
CREATE INDEX IX_HoaDon_NgayLap ON HoaDon(NgayLap);
```

2. **Index trên TrangThai**: L?c hóa ??n ?ã thanh toán
```sql
CREATE INDEX IX_HoaDon_TrangThai ON HoaDon(TrangThai);
```

3. **S? d?ng Stored Procedure**: Gi?m network traffic
```csharp
// Thay vì query string, dùng SP
string query = "EXEC sp_GetBaoCaoDoanhThu @TuNgay, @DenNgay";
```

## ?? Troubleshooting

### Problem 1: Bi?u ?? không hi?n th?
**Solution**: Ki?m tra reference `System.Windows.Forms.DataVisualization`

### Problem 2: L?i encoding ti?ng Vi?t khi xu?t Excel
**Solution**: File CSV s? d?ng UTF-8 encoding

### Problem 3: Không l?y ???c ID ng??i dùng
**Solution**: Implement method `GetCurrentUserId()` ?úng v?i h? th?ng login

### Problem 4: D? li?u không ?úng
**Solution**: Ki?m tra TrangThai hóa ??n ph?i là "?ã thanh toán"

## ?? Related Documents
- [H??ng D?n Chi Ti?t](BaoCaoDoanhThu_HuongDan.md)
- [SQL Scripts](../SQL/Create_View_BaoCaoDoanhThu.sql)
- [API Documentation](API_Documentation.md)

## ?? Future Enhancements

### Version 2.0 (Planned)
- [ ] Dashboard v?i nhi?u widget
- [ ] So sánh doanh thu gi?a các kho?ng th?i gian
- [ ] Xu?t PDF v?i template chuyên nghi?p
- [ ] G?i email t? ??ng
- [ ] L?ch h?n t?o báo cáo ??nh k?

### Version 2.1 (Planned)
- [ ] D? ?oán doanh thu b?ng ML
- [ ] Phân tích theo s?n ph?m
- [ ] Phân tích theo ca làm vi?c
- [ ] Phân tích theo khu v?c/bàn
- [ ] Mobile app integration

## ?? Contributors
- **Developer**: QuanLyQuanCaPhe Team
- **Designer**: UI/UX Team
- **QA**: Testing Team

## ?? License
Copyright © 2024 QuanLyQuanCaPhe. All rights reserved.

## ?? Support
- Email: support@quanlycaphe.com
- Phone: 1900-xxxx
- Website: www.quanlycaphe.com

---
**Last Updated**: 2024
**Version**: 1.0.0
