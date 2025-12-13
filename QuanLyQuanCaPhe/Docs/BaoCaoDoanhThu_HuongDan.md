# BÁO CÁO DOANH THU - H??NG D?N S? D?NG

## ?? Mô t?
Form **BaoCaoDoanhThu** ???c thi?t k? ?? xem và qu?n lý báo cáo doanh thu c?a quán cà phê theo kho?ng th?i gian.

## ?? Các Tính N?ng Chính

### 1. **Xem Báo Cáo Theo Kho?ng Th?i Gian**
- Ch?n **T? ngày** và **??n ngày**
- Nh?n nút **Xem Báo Cáo** ?? hi?n th? d? li?u
- D? li?u ???c hi?n th? theo t?ng ngày

### 2. **Hi?n Th? D? Li?u**
- **DataGridView**: Hi?n th? chi ti?t doanh thu theo ngày
  - C?t "Ngày": Ngày giao d?ch
  - C?t "S? Hóa ??n": T?ng s? hóa ??n trong ngày
  - C?t "Doanh Thu": T?ng doanh thu trong ngày (VN?)

### 3. **Bi?u ??**
- **Bi?u ?? c?t**: Hi?n th? doanh thu theo t?ng ngày
- **???ng trung bình**: ???ng nét ??t màu ?? hi?n th? doanh thu trung bình

### 4. **Th?ng Kê**
- **T?ng doanh thu**: T?ng doanh thu trong kho?ng th?i gian ?ã ch?n
- **S? hóa ??n**: T?ng s? hóa ??n ?ã thanh toán
- **Doanh thu trung bình**: Doanh thu trung bình m?i ngày

### 5. **Ch?c N?ng**

#### a. T?i L?i D? Li?u
- Làm m?i d? li?u báo cáo v?i kho?ng th?i gian hi?n t?i

#### b. Xu?t Excel
- Xu?t d? li?u báo cáo ra file CSV
- File có th? m? b?ng Microsoft Excel
- Bao g?m:
  - Tiêu ?? báo cáo
  - Kho?ng th?i gian
  - D? li?u chi ti?t
  - Th?ng kê t?ng h?p

#### c. L?u Báo Cáo
- L?u báo cáo vào database (b?ng `BaoCao_DoanhThu`)
- Ghi nh?n:
  - Kho?ng th?i gian báo cáo
  - T?ng doanh thu
  - Ng??i l?p báo cáo

## ?? C?u Trúc Database

### B?ng: BaoCao_DoanhThu
```sql
CREATE TABLE BaoCao_DoanhThu (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TuNgay DATE,
    DenNgay DATE,
    TongDoanhThu DECIMAL(18,2),
    NguoiLap INT FOREIGN KEY REFERENCES NhanVien(Id),
    CHECK (DenNgay >= TuNgay)
);
```

### Views H? Tr?
1. **v_BaoCao_DoanhThuTheoNgay**: Báo cáo doanh thu theo ngày
2. **v_BaoCao_DoanhThuTheoThang**: Báo cáo doanh thu theo tháng
3. **v_LichSuBaoCaoDoanhThu**: L?ch s? các báo cáo ?ã l?u
4. **v_ThongKeBaoCaoTheoNhanVien**: Th?ng kê báo cáo theo nhân viên

### Stored Procedures
1. **sp_GetBaoCaoDoanhThu**: L?y d? li?u báo cáo theo kho?ng th?i gian
2. **sp_LuuBaoCaoDoanhThu**: L?u báo cáo vào database

## ?? H??ng D?n S? D?ng

### B??c 1: M? Form
```csharp
BaoCaoDoanhThu form = new BaoCaoDoanhThu();
form.ShowDialog();
```

### B??c 2: Ch?n Kho?ng Th?i Gian
- M?c ??nh hi?n th? d? li?u tháng hi?n t?i
- Có th? thay ??i b?ng cách ch?n ngày b?t ??u và k?t thúc

### B??c 3: Xem Báo Cáo
- Nh?n nút **"Xem Báo Cáo"** ?? t?i d? li?u

### B??c 4: Phân Tích
- Xem b?ng d? li?u chi ti?t
- Quan sát bi?u ?? ?? nh?n bi?t xu h??ng
- Ki?m tra các ch? s? th?ng kê

### B??c 5: Xu?t Báo Cáo (Tùy Ch?n)
- Nh?n **"Xu?t Excel"** ?? l?u file
- Ch?n v? trí l?u file
- M? file ?? xem ho?c in ?n

### B??c 6: L?u Báo Cáo (Tùy Ch?n)
- Nh?n **"L?u Báo Cáo"** ?? l?u vào database
- Dùng ?? theo dõi l?ch s? các báo cáo ?ã t?o

## ?? C?u Hình

### Thay ??i ID Ng??i Dùng
Trong file `BaoCaoDoanhThu.cs`, method `GetCurrentUserId()`:

```csharp
private int? GetCurrentUserId()
{
    // TODO: Thay th? b?ng cách l?y ID ng??i dùng th?c t? t? session/login
    // Ví d?: return UserSession.CurrentUserId;
    
    // Ho?c tích h?p v?i form login
 // return LoginForm.CurrentUserId;
}
```

### Tùy Ch?nh Query
Có th? s?a ??i query trong method `LoadBaoCao()` ?? thêm ?i?u ki?n l?c:
- Theo chi nhánh
- Theo nhân viên
- Theo ph??ng th?c thanh toán
- v.v.

## ?? Giao Di?n

### Màu S?c
- **Tiêu ??**: DarkBlue (#00008B)
- **Nút "Xem Báo Cáo"**: DodgerBlue (#1E90FF) - Tr?ng
- **Nút "L?u Báo Cáo"**: MediumSeaGreen (#3CB371) - Tr?ng
- **T?ng doanh thu**: Green (#008000)
- **S? hóa ??n**: Blue (#0000FF)
- **Doanh thu trung bình**: DarkOrange (#FF8C00)

### Kích Th??c Form
- **Width**: 984px
- **Height**: 641px
- **Position**: Center Screen
- **Border**: FixedDialog
- **MaximizeBox**: False

## ?? Cài ??t

### 1. Ch?y SQL Script
```bash
# Ch?y file SQL ?? t?o views và stored procedures
Execute: QuanLyQuanCaPhe\SQL\Create_View_BaoCaoDoanhThu.sql
```

### 2. Thêm Reference
??m b?o project có reference:
- `System.Windows.Forms.DataVisualization`

### 3. Build Project
```bash
Build Solution (Ctrl + Shift + B)
```

## ?? Ví D? D? Li?u

### Input
- T? ngày: 01/01/2024
- ??n ngày: 31/01/2024

### Output
| Ngày | S? Hóa ??n | Doanh Thu (VN?) |
|------|------------|-----------------|
| 01/01/2024 | 25 | 5,250,000 |
| 02/01/2024 | 30 | 6,100,000 |
| ... | ... | ... |

### Th?ng Kê
- T?ng doanh thu: 150,000,000 ?
- S? hóa ??n: 750
- Doanh thu trung bình: 4,838,710 ?/ngày

## ?? L?u Ý

1. **Ki?m tra k?t n?i database** tr??c khi s? d?ng
2. **Ch? tính hóa ??n ?ã thanh toán** (TrangThai = '?ã thanh toán')
3. **Ngày b?t ??u ph?i ? ngày k?t thúc**
4. **ID ng??i l?p** ph?i t?n t?i trong b?ng NhanVien
5. **File CSV** s? d?ng encoding UTF-8 ?? hi?n th? ti?ng Vi?t

## ?? X? Lý L?i

### L?i th??ng g?p:

1. **"Không th? k?t n?i ??n database"**
   - Ki?m tra connection string
   - ??m b?o SQL Server ?ang ch?y

2. **"Ngày b?t ??u ph?i nh? h?n ho?c b?ng ngày k?t thúc"**
   - Ch?n l?i kho?ng th?i gian h?p l?

3. **"Không xác ??nh ???c ng??i l?p báo cáo"**
   - ??m b?o ?ã ??ng nh?p
   - Ki?m tra method `GetCurrentUserId()`

4. **"Không có d? li?u ?? xu?t/l?u"**
   - Ki?m tra có d? li?u trong kho?ng th?i gian ?ã ch?n
   - ??m b?o có hóa ??n ?ã thanh toán

## ?? H? Tr?

N?u g?p v?n ??, vui lòng ki?m tra:
1. Log file trong th? m?c Logs
2. Error message trong MessageBox
3. SQL Server Error Log
4. Visual Studio Output Window

## ?? Tính N?ng M? R?ng (Future)

- [ ] Báo cáo theo tu?n/tháng/quý/n?m
- [ ] So sánh doanh thu gi?a các kho?ng th?i gian
- [ ] Xu?t PDF
- [ ] G?i báo cáo qua email
- [ ] Dashboard t?ng quan
- [ ] D? ?oán doanh thu
- [ ] Phân tích theo s?n ph?m
- [ ] Phân tích theo nhân viên

## ?? License
Copyright © 2024 QuanLyQuanCaPhe
