-- =============================================
--  ĐỒ ÁN: QUẢN LÝ QUÁN CÀ PHÊ
-- =============================================

-- Xóa database cũ nếu có
USE master;
IF DB_ID('QuanLyCaPhe') IS NOT NULL
    DROP DATABASE QuanLyCaPhe;
GO

-- Tạo database mới
CREATE DATABASE QuanLyCaPhe;
GO
USE QuanLyCaPhe;
GO

-- ====================
-- 1. Bảng NGUOIDUNG
-- ====================
CREATE TABLE NguoiDung (
	TenDangNhap NVARCHAR(50) PRIMARY KEY NOT NULL,
    -- MaNguoiDung AS ('ND' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    MatKhau NVARCHAR(1000) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT N'Nhân viên', -- Admin | Nhân viên
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động' -- Đã khóa | Hoạt động
);
GO

-- =====================
-- 2. Bảng NHANVIEN
--  ====================
CREATE TABLE NhanVien (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaNhanVien AS ('NV' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) DEFAULT N'Nam' NOT NULL, -- Nam | Nữ
    NgaySinh DATE CHECK(NgaySinh < GETDATE()) NOT NULL,
    SDT VARCHAR(15) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    Luong DECIMAL(18,2) CHECK(Luong >= 0) DEFAULT 0,
	TrangThai NVARCHAR(20) DEFAULT N'Hoạt động', -- Hoạt động | Tạm nghỉ | Đã nghỉ việc
    TenDangNhap NVARCHAR(50) FOREIGN KEY REFERENCES NguoiDung(TenDangNhap)
);
GO

-- ====================
-- 3. Bảng DANHMUC: Ví dụ: Cà phê, Sinh tố, Trà sữa,...
-- ====================
CREATE TABLE DanhMuc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaDanhMuc AS ('DM' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    TenDanhMuc NVARCHAR(100) UNIQUE NOT NULL DEFAULT N'Danh mục chưa có tên'
);
GO

-- ====================
-- 4. Bảng SANPHAM: Ví dụ: Cà phê: Cà phê đen, đá, bạc xỉu | Sinh tố: bơ, dâu, sầu riêng,...
-- ====================
CREATE TABLE SanPham (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaSP AS ('SP' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    TenSP NVARCHAR(100) NOT NULL DEFAULT N'Sản phẩm chưa có tên',
    DonGia DECIMAL(18,2) DEFAULT 0,
    DonViTinh NVARCHAR(50) NOT NULL DEFAULT N'Ly',
    MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(Id),
    TrangThai NVARCHAR(20) DEFAULT N'Còn bán' -- Còn bán | Hết
);
GO

-- ================
-- 5. Bảng BAN
-- ================
CREATE TABLE Ban (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaBan AS ('B' + RIGHT('00' + CAST(Id AS VARCHAR(2)), 2)) PERSISTED,
    TenBan NVARCHAR(50) NOT NULL DEFAULT N'Bàn chưa có tên',
	ViTri NVARCHAR(100) NOT NULL DEFAULT N'Tầng trệt', -- Phân khu: tầng trệt, lầu 1, lầu 2,...
    TrangThai NVARCHAR(20) DEFAULT N'Còn trống' -- Có người | Còn trống
);
GO

-- ====================
-- 6. Bảng HOADON
-- ====================
CREATE TABLE HoaDon (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaHoaDon AS ('HD' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    MaBan INT FOREIGN KEY REFERENCES Ban(Id),
    MaNhanVien INT FOREIGN KEY REFERENCES NhanVien(Id),
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) DEFAULT 0,
	GiamGiaPhanTram DECIMAL(5,2) CHECK(GiamGiaPhanTram >= 0 AND GiamGiaPhanTram <= 100) DEFAULT 0, -- 💡 Giảm theo % (ví dụ giảm 10%)
	GiamGiaTien DECIMAL(18,2) CHECK(GiamGiaTien >= 0) DEFAULT 0, -- Giảm theo tiền (VD: giảm 10000đ)
	ThanhTienSauGiam AS (
        CASE 
            WHEN GiamGiaPhanTram > 0 THEN (TongTien - (TongTien * GiamGiaPhanTram / 100))
            WHEN GiamGiaTien > 0 THEN (TongTien - GiamGiaTien)
            ELSE TongTien
        END
    ) PERSISTED,
    TrangThai NVARCHAR(20) DEFAULT N'Chưa thanh toán' CHECK(TrangThai IN (N'Đã thanh toán', N'Chưa thanh toán')), -- Đã thanh toán | Chưa thanh toán
	CONSTRAINT CK_GiamGia_ChiMotLoai CHECK(
        NOT (GiamGiaPhanTram > 0 AND GiamGiaTien > 0)
    )
);
GO

-- ====================
-- 7. Bảng CHITIETHOADON
-- ====================
CREATE TABLE ChiTietHoaDon (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaCTHD AS ('CT' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(Id),
    MaSP INT FOREIGN KEY REFERENCES SanPham(Id),
    SoLuong INT CHECK(SoLuong > 0),
    DonGia DECIMAL(18,2),
    ThanhTien AS (SoLuong * DonGia) PERSISTED
);
GO

-- ====================
-- 8. Bảng BAOCAO_DOANHTHU
-- ====================
CREATE TABLE BaoCao_DoanhThu (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    -- MaBaoCao AS ('BC' + RIGHT('000' + CAST(Id AS VARCHAR(3)), 3)) PERSISTED,
    TuNgay DATE,
    DenNgay DATE,
    TongDoanhThu DECIMAL(18,2),
    NguoiLap INT FOREIGN KEY REFERENCES NhanVien(Id),
	CHECK (DenNgay >= TuNgay) -- ngày kết thúc phải >= ngày bắt đầu
);
GO


-- ====================
-- RÀNG BUỘC
-- ====================


-- View để xem món bán chạy
CREATE VIEW v_BaoCao_MonBanChay AS
SELECT TOP 10 
    SP.TenSP, 
    SUM(CT.SoLuong) AS TongSoLuong
FROM ChiTietHoaDon CT
JOIN SanPham SP ON CT.MaSP = SP.Id
JOIN HoaDon HD ON CT.MaHoaDon = HD.Id
WHERE HD.TrangThai = N'Đã thanh toán'
GROUP BY SP.TenSP
ORDER BY TongSoLuong DESC;
GO

