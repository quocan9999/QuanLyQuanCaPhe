-- Thêm dữ liệu mẫu cho hệ thống Quản lý quán cà phê
-- Giả sử database và các bảng đã được tạo theo script QuanLyCaPhe_data.sql

USE QuanLyCaPhe;

/*
============================================================
1. DỮ LIỆU MẪU CHO BẢNG NGUOIDUNG
============================================================*/
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro)
VALUES
    (N'admin',       N'admin',   N'Admin'), -- Quản trị hệ thống
    (N'nhanvien1',  N'nhanvien1',   N'Nhân viên'),
    (N'nhanvien2',  N'nhanvien2',   N'Nhân viên');


/*
============================================================
2. DỮ LIỆU MẪU CHO BẢNG NHANVIEN
============================================================*/
INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi, Luong, TenDangNhap, TrangThai)
VALUES
    (N'Nguyễn Văn A', N'Nam', '1999-05-10', '0901111222', N'nguyenvana@coffee.vn', N'Quận 1, TP. HCM', 8000000, N'admin',       N'Hoạt động'),
    (N'Trần Thị B',   N'Nữ', '2000-08-21', '0902222333', N'tranthib@coffee.vn',   N'Quận 3, TP. HCM', 6000000, N'nhanvien1',  N'Hoạt động'),
    (N'Lê Quốc C',    N'Nam', '1998-12-01', '0903333444', N'lequocc@coffee.vn',    N'Thủ Đức, TP. HCM', 5500000, N'nhanvien2', N'Hoạt động');


/*
============================================================
3. DỮ LIỆU MẪU CHO BẢNG DANHMUC
============================================================*/
INSERT INTO DanhMuc (TenDanhMuc)
VALUES
    (N'Cà phê'),
    (N'Trà sữa'),
    (N'Sinh tố'),
    (N'Nước ngọt');


/*
============================================================
4. DỮ LIỆU MẪU CHO BẢNG SANPHAM
============================================================*/
DECLARE @DM_CaPhe    INT,
        @DM_TraSua   INT,
        @DM_SinhTo   INT,
        @DM_NuocNgot INT;

SELECT @DM_CaPhe    = Id FROM DanhMuc WHERE TenDanhMuc = N'Cà phê';
SELECT @DM_TraSua   = Id FROM DanhMuc WHERE TenDanhMuc = N'Trà sữa';
SELECT @DM_SinhTo   = Id FROM DanhMuc WHERE TenDanhMuc = N'Sinh tố';
SELECT @DM_NuocNgot = Id FROM DanhMuc WHERE TenDanhMuc = N'Nước ngọt';

INSERT INTO SanPham (TenSP, DonGia, DonViTinh, MaDanhMuc, TrangThai)
VALUES
    (N'Cà phê đen đá',       25000, N'Ly',  @DM_CaPhe,    N'Còn bán'),
    (N'Cà phê sữa',          30000, N'Ly',  @DM_CaPhe,    N'Còn bán'),
    (N'Trà sữa trân châu',   35000, N'Ly',  @DM_TraSua,   N'Còn bán'),
    (N'Sinh tố bơ',          40000, N'Ly',  @DM_SinhTo,   N'Còn bán'),
    (N'Coca Cola',           20000, N'Lon', @DM_NuocNgot, N'Còn bán');


/*
============================================================
5. DỮ LIỆU MẪU CHO BẢNG BAN
============================================================*/
INSERT INTO Ban (TenBan, ViTri, TrangThai)
VALUES
    (N'Bàn 1', N'Tầng trệt', N'Còn trống'),
    (N'Bàn 2', N'Tầng trệt', N'Còn trống'),
    (N'Bàn 3', N'Lầu 1',     N'Có người'),
    (N'Bàn 4', N'Lầu 1',     N'Còn trống');


/*
============================================================
6. DỮ LIỆU MẪU CHO BẢNG HOADON VÀ CHITIETHOADON
============================================================*/
DECLARE @NV_Admin INT,
        @NV_01    INT,
        @NV_02    INT;

SELECT @NV_Admin = Id FROM NhanVien WHERE TenDangNhap = N'admin';
SELECT @NV_01    = Id FROM NhanVien WHERE TenDangNhap = N'nhanvien1';
SELECT @NV_02    = Id FROM NhanVien WHERE TenDangNhap = N'nhanvien2';

DECLARE @Ban1 INT,
        @Ban2 INT,
        @Ban3 INT;

SELECT @Ban1 = Id FROM Ban WHERE TenBan = N'Bàn 1';
SELECT @Ban2 = Id FROM Ban WHERE TenBan = N'Bàn 2';
SELECT @Ban3 = Id FROM Ban WHERE TenBan = N'Bàn 3';

DECLARE @SP_CFDenDa   INT,
        @SP_CFSua     INT,
        @SP_TraSuaTC  INT,
        @SP_SinhToBo  INT,
        @SP_Coca      INT;

SELECT @SP_CFDenDa  = Id FROM SanPham WHERE TenSP = N'Cà phê đen đá';
SELECT @SP_CFSua    = Id FROM SanPham WHERE TenSP = N'Cà phê sữa';
SELECT @SP_TraSuaTC = Id FROM SanPham WHERE TenSP = N'Trà sữa trân châu';
SELECT @SP_SinhToBo = Id FROM SanPham WHERE TenSP = N'Sinh tố bơ';
SELECT @SP_Coca     = Id FROM SanPham WHERE TenSP = N'Coca Cola';

DECLARE @HD1 INT,
        @HD2 INT,
        @HD3 INT;

-- Hóa đơn 1: Bàn 1, đã thanh toán, không giảm giá
INSERT INTO HoaDon (MaBan, MaNhanVien, NgayLap, TongTien, GiamGiaPhanTram, GiamGiaTien, TrangThai)
VALUES (@Ban1, @NV_01, DATEADD(DAY, -1, GETDATE()), 0, 0, 0, N'Đã thanh toán');
SET @HD1 = SCOPE_IDENTITY();

-- Hóa đơn 2: Bàn 3, đã thanh toán, giảm 10%
INSERT INTO HoaDon (MaBan, MaNhanVien, NgayLap, TongTien, GiamGiaPhanTram, GiamGiaTien, TrangThai)
VALUES (@Ban3, @NV_Admin, DATEADD(DAY, -2, GETDATE()), 0, 10, 0, N'Đã thanh toán');
SET @HD2 = SCOPE_IDENTITY();

-- Hóa đơn 3: Bàn 2, chưa thanh toán (đang phục vụ)
INSERT INTO HoaDon (MaBan, MaNhanVien, NgayLap, TongTien, GiamGiaPhanTram, GiamGiaTien, TrangThai)
VALUES (@Ban2, @NV_01, GETDATE(), 0, 0, 0, N'Chưa thanh toán');
SET @HD3 = SCOPE_IDENTITY();

-- Chi tiết hóa đơn 1: 1 CF đen đá + 1 Trà sữa TC + 1 Coca (tổng 80.000)
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSP, SoLuong, DonGia)
VALUES
    (@HD1, @SP_CFDenDa,  1, 25000),
    (@HD1, @SP_TraSuaTC, 1, 35000),
    (@HD1, @SP_Coca,     1, 20000);

-- Chi tiết hóa đơn 2: 2 CF sữa + 1 Sinh tố bơ (tổng 100.000, giảm 10% còn 90.000)
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSP, SoLuong, DonGia)
VALUES
    (@HD2, @SP_CFSua,    2, 30000),
    (@HD2, @SP_SinhToBo, 1, 40000);

-- Chi tiết hóa đơn 3: 1 Trà sữa TC + 1 Coca (tổng 55.000, chưa thanh toán)
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSP, SoLuong, DonGia)
VALUES
    (@HD3, @SP_TraSuaTC, 1, 35000),
    (@HD3, @SP_Coca,     1, 20000);

-- Cập nhật lại tổng tiền cho các hóa đơn dựa trên chi tiết
UPDATE HD
SET TongTien = T.SumThanhTien
FROM HoaDon AS HD
JOIN (
    SELECT MaHoaDon, SUM(ThanhTien) AS SumThanhTien
    FROM ChiTietHoaDon
    GROUP BY MaHoaDon
) AS T
    ON HD.Id = T.MaHoaDon;


/*
============================================================
7. DỮ LIỆU MẪU CHO BẢNG BAOCAO_DOANHTHU
============================================================*/
-- Báo cáo doanh thu cho 2 ngày gần nhất dựa trên các hóa đơn đã thanh toán
INSERT INTO BaoCao_DoanhThu (TuNgay, DenNgay, TongDoanhThu, NguoiLap)
SELECT 
    CONVERT(DATE, MIN(NgayLap))      AS TuNgay,
    CONVERT(DATE, MAX(NgayLap))      AS DenNgay,
    SUM(ThanhTienSauGiam)            AS TongDoanhThu,
    @NV_Admin                        AS NguoiLap
FROM HoaDon
WHERE TrangThai = N'Đã thanh toán';

-- KẾT THÚC SCRIPT THÊM DỮ LIỆU MẪU