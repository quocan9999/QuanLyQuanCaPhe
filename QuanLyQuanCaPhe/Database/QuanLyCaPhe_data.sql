-- =============================================
--  ĐỒ ÁN: QUẢN LÝ QUÁN CÀ PHÊ
-- =============================================

-- Xóa database cũ nếu có
USE master;
IF DB_ID(N'QuanLyCaPhe') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyCaPhe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyCaPhe;
END;
GO
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
    NguoiLap INT FOREIGN KEY REFERENCES NhanVien(Id),
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


/*
============================================================
1. DỮ LIỆU MẪU CHO BẢNG NGUOIDUNG
============================================================*/
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro)
VALUES
    (N'admin',       N'admin',   N'Admin'), -- Quản trị hệ thống
    (N'nhanvien1',  N'nhanvien1',   N'Nhân viên'),
    (N'nhanvien2',  N'nhanvien2',   N'Nhân viên');
GO

/*
============================================================
2. DỮ LIỆU MẪU CHO BẢNG NHANVIEN
============================================================*/
INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi, Luong, TenDangNhap, TrangThai)
VALUES
    (N'Nguyễn Văn A', N'Nam', '1999-05-10', '0901111222', N'nguyenvana@coffee.vn', N'Quận 1, TP. HCM', 8000000, N'admin',       N'Hoạt động'),
    (N'Trần Thị B',   N'Nữ', '2000-08-21', '0902222333', N'tranthib@coffee.vn',   N'Quận 3, TP. HCM', 6000000, N'nhanvien1',  N'Hoạt động'),
    (N'Lê Quốc C',    N'Nam', '1998-12-01', '0903333444', N'lequocc@coffee.vn',    N'Thủ Đức, TP. HCM', 5500000, N'nhanvien2', N'Hoạt động');
GO

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
GO

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
GO

/*
============================================================
5. DỮ LIỆU MẪU CHO BẢNG BAN
============================================================*/
INSERT INTO Ban (TenBan, ViTri, TrangThai)
VALUES
    (N'Bàn 1', N'Tầng trệt', N'Còn trống'),
    (N'Bàn 2', N'Tầng trệt', N'Còn trống'),
    (N'Bàn 3', N'Lầu 1',     N'Còn trống'),
    (N'Bàn 4', N'Lầu 1',     N'Còn trống');
GO

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
INSERT INTO HoaDon (MaBan, NguoiLap, NgayLap, TongTien, GiamGiaPhanTram, GiamGiaTien, TrangThai)
VALUES (@Ban1, @NV_01, DATEADD(DAY, -1, GETDATE()), 0, 0, 0, N'Đã thanh toán');
SET @HD1 = SCOPE_IDENTITY();

-- Hóa đơn 2: Bàn 3, đã thanh toán, giảm 10%
INSERT INTO HoaDon (MaBan, NguoiLap, NgayLap, TongTien, GiamGiaPhanTram, GiamGiaTien, TrangThai)
VALUES (@Ban3, @NV_Admin, DATEADD(DAY, -2, GETDATE()), 0, 10, 0, N'Đã thanh toán');
SET @HD2 = SCOPE_IDENTITY();

-- Hóa đơn 3: Bàn 2, chưa thanh toán (đang phục vụ)
INSERT INTO HoaDon (MaBan, NguoiLap, NgayLap, TongTien, GiamGiaPhanTram, GiamGiaTien, TrangThai)
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
GO

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
GO


/*
============================================================
					STORE PROCEDURE
============================================================*/
CREATE OR ALTER PROC usp_GetTableList
AS 
BEGIN
	SELECT 
		Id,
		TenBan,
		ViTri,
		TrangThai
	FROM dbo.Ban 
	ORDER BY ViTri, TenBan
END
GO

CREATE OR ALTER PROC usp_Login
@userName NVARCHAR(100), @passWord NVARCHAR(1000)
AS
BEGIN
	SELECT 
	    ND.TenDangNhap,
		VaiTro,
		NgayTao,
		ND.TrangThai,
        NV.HoTen,
        NV.GioiTinh,
        NV.NgaySinh,
        NV.SDT,
        NV.Email,
        NV.DiaChi,
        NV.Luong,
        NV.TrangThai
	FROM dbo.NguoiDung AS ND LEFT JOIN dbo.NhanVien AS NV ON NV.TenDangNhap = ND.TenDangNhap
	WHERE ND.TenDangNhap = @userName 
	  AND MatKhau = @passWord 
	  AND ND.TrangThai = N'Hoạt động'
END
GO

-- View: Báo cáo doanh thu theo ngày
IF OBJECT_ID('v_BaoCao_DoanhThuTheoNgay', 'V') IS NOT NULL
    DROP VIEW v_BaoCao_DoanhThuTheoNgay;
GO

CREATE VIEW v_BaoCao_DoanhThuTheoNgay
AS
SELECT 
    CAST(hd.NgayLap AS DATE) AS Ngay,
    COUNT(DISTINCT hd.Id) AS SoHoaDon,
    SUM(hd.TongTien) AS DoanhThu,
    AVG(hd.TongTien) AS DoanhThuTrungBinhHoaDon,
    MIN(hd.TongTien) AS DoanhThuThapNhat,
    MAX(hd.TongTien) AS DoanhThuCaoNhat
FROM HoaDon hd
WHERE hd.TrangThai = N'Đã thanh toán'
GROUP BY CAST(hd.NgayLap AS DATE);
GO

-- View: Báo cáo doanh thu theo tháng
IF OBJECT_ID('v_BaoCao_DoanhThuTheoThang', 'V') IS NOT NULL
    DROP VIEW v_BaoCao_DoanhThuTheoThang;
GO

CREATE VIEW v_BaoCao_DoanhThuTheoThang
AS
SELECT 
    YEAR(hd.NgayLap) AS Nam,
    MONTH(hd.NgayLap) AS Thang,
    COUNT(DISTINCT hd.Id) AS SoHoaDon,
    SUM(hd.TongTien) AS DoanhThu
FROM HoaDon hd
WHERE hd.TrangThai = N'Đã thanh toán'
GROUP BY YEAR(hd.NgayLap), MONTH(hd.NgayLap);
GO

-- View: Lịch sử báo cáo đã lưu
IF OBJECT_ID('v_LichSuBaoCaoDoanhThu', 'V') IS NOT NULL
    DROP VIEW v_LichSuBaoCaoDoanhThu;
GO

CREATE VIEW v_LichSuBaoCaoDoanhThu
AS
SELECT 
    bc.Id,
    bc.TuNgay,
    bc.DenNgay,
    bc.TongDoanhThu,
    nv.HoTen AS NguoiLap,
    nv.Id AS NguoiLapId,
    DATEDIFF(DAY, bc.TuNgay, bc.DenNgay) + 1 AS SoNgay,
    bc.TongDoanhThu / (DATEDIFF(DAY, bc.TuNgay, bc.DenNgay) + 1) AS DoanhThuTrungBinhNgay
FROM BaoCao_DoanhThu bc
LEFT JOIN NhanVien nv ON bc.NguoiLap = nv.Id;
GO

-- View: Tổng hợp doanh thu theo nhân viên lập báo cáo
IF OBJECT_ID('v_ThongKeBaoCaoTheoNhanVien', 'V') IS NOT NULL
    DROP VIEW v_ThongKeBaoCaoTheoNhanVien;
GO

CREATE VIEW v_ThongKeBaoCaoTheoNhanVien
AS
SELECT 
    nv.Id AS NhanVienId,
    nv.HoTen,
    COUNT(bc.Id) AS SoBaoCaoLap,
    MIN(bc.TuNgay) AS BaoCaoDauTien,
    MAX(bc.DenNgay) AS BaoCaoGanNhat,
    SUM(bc.TongDoanhThu) AS TongDoanhThuBaoCao
FROM NhanVien nv
LEFT JOIN BaoCao_DoanhThu bc ON nv.Id = bc.NguoiLap
GROUP BY nv.Id, nv.HoTen;
GO

-- Stored Procedure: Lấy báo cáo doanh thu theo khoảng thời gian
IF OBJECT_ID('sp_GetBaoCaoDoanhThu', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetBaoCaoDoanhThu;
GO

CREATE PROCEDURE sp_GetBaoCaoDoanhThu
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Kiểm tra ngày hợp lệ
    IF @TuNgay > @DenNgay
    BEGIN
        RAISERROR(N'Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc', 16, 1);
        RETURN;
    END
  
    -- Lấy dữ liệu doanh thu
    SELECT 
        CAST(hd.NgayLap AS DATE) AS Ngay,
        COUNT(DISTINCT hd.Id) AS SoHoaDon,
        SUM(hd.TongTien) AS DoanhThu
    FROM HoaDon hd
    WHERE hd.NgayLap >= @TuNgay 
      AND hd.NgayLap <= @DenNgay
      AND hd.TrangThai = N'Đã thanh toán'
    GROUP BY CAST(hd.NgayLap AS DATE)
    ORDER BY Ngay;
END
GO

-- Stored Procedure: Lưu báo cáo doanh thu
IF OBJECT_ID('sp_LuuBaoCaoDoanhThu', 'P') IS NOT NULL
    DROP PROCEDURE sp_LuuBaoCaoDoanhThu;
GO

CREATE PROCEDURE sp_LuuBaoCaoDoanhThu
    @TuNgay DATE,
    @DenNgay DATE,
    @TongDoanhThu DECIMAL(18,2),
    @NguoiLap INT,
    @BaoCaoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Kiểm tra ngày hợp lệ
        IF @TuNgay > @DenNgay
        BEGIN
            RAISERROR(N'Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc', 16, 1);
            RETURN;
        END
        
        -- Kiểm tra nhân viên tồn tại
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE Id = @NguoiLap)
        BEGIN
            RAISERROR(N'Nhân viên không tồn tại', 16, 1);
            RETURN;
        END
  
        -- Thêm báo cáo mới
        INSERT INTO BaoCao_DoanhThu (TuNgay, DenNgay, TongDoanhThu, NguoiLap)
        VALUES (@TuNgay, @DenNgay, @TongDoanhThu, @NguoiLap);
   
        SET @BaoCaoId = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
        
        SELECT @BaoCaoId AS BaoCaoId, N'Lưu báo cáo thành công' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

--                           TRIGGER
-- Xóa trigger cũ nếu tồn tại để tránh lỗi trùng lặp
IF OBJECT_ID('trg_CapNhatTrangThaiBan', 'TR') IS NOT NULL
    DROP TRIGGER trg_CapNhatTrangThaiBan;
GO

CREATE TRIGGER trg_CapNhatTrangThaiBan
ON HoaDon
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- TRƯỜNG HỢP 1 & 2: KHI THÊM MỚI HOẶC CẬP NHẬT HÓA ĐƠN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        -- nếu có hóa đơn mới trạng thái 'chưa thanh toán' -> cập nhật bàn thành 'có người'
        UPDATE Ban
        SET TrangThai = N'Có người'
        FROM Ban b
        JOIN inserted i ON b.Id = i.MaBan
        WHERE i.TrangThai = N'Chưa thanh toán';

        -- nếu hóa đơn chuyển sang 'đã thanh toán' -> cập nhật bàn thành 'còn trống'
        UPDATE Ban
        SET TrangThai = N'Còn trống'
        FROM Ban b
        JOIN inserted i ON b.Id = i.MaBan
        WHERE i.TrangThai = N'Đã thanh toán';
    END

    -- TRƯỜNG HỢP 3: KHI XÓA HÓA ĐƠN (HỦY BÀN)
    -- chỉ chạy khi có bảng deleted mà không có bảng inserted (tức là thao tác delete)
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        -- cập nhật lại trạng thái bàn thành 'còn trống' khi xóa hóa đơn chưa thanh toán
        UPDATE Ban
        SET TrangThai = N'Còn trống'
        FROM Ban b
        JOIN deleted d ON b.Id = d.MaBan
        WHERE d.TrangThai = N'Chưa thanh toán';
    END
END
GO

-- Store Procedure chuyển bàn
CREATE OR ALTER PROC usp_ChuyenBan
@idBanCu INT,
@idBanMoi INT
AS
BEGIN
    DECLARE @idHoaDon INT;

    -- lấy id hóa đơn chưa thanh toán của bàn cũ
    SELECT @idHoaDon = Id
    FROM dbo.HoaDon
    WHERE MaBan = @idBanCu AND TrangThai = N'Chưa thanh toán';

    -- kiểm tra nếu không có hóa đơn thì dừng lại
    IF (@idHoaDon IS NULL)
    BEGIN
        RETURN; 
    END

    -- chuyển hóa đơn sang bàn mới
    UPDATE dbo.HoaDon
    SET MaBan = @idBanMoi
    WHERE Id = @idHoaDon;

    -- cập nhật trạng thái bàn cũ thành 'còn trống'
    UPDATE dbo.Ban
    SET TrangThai = N'Còn trống'
    WHERE Id = @idBanCu;

    -- cập nhật trạng thái bàn mới thành 'có người'
    UPDATE dbo.Ban
    SET TrangThai = N'Có người'
    WHERE Id = @idBanMoi;
END
GO

-- =============================================
-- 1. SP LẤY THÔNG TIN HÓA ĐƠN ĐỂ HIỂN THỊ
-- =============================================
CREATE OR ALTER PROC usp_LayThongTinThanhToan
    @idBan INT
AS
BEGIN
    -- Lấy thông tin chung của hóa đơn chưa thanh toán
    SELECT 
        hd.Id AS MaHoaDon,
        hd.NgayLap AS GioVao,
        b.TenBan,
        b.ViTri,
        ISNULL(SUM(ct.SoLuong * ct.DonGia), 0) AS TongTienTamTinh
    FROM dbo.HoaDon hd
    JOIN dbo.Ban b ON hd.MaBan = b.Id
    LEFT JOIN dbo.ChiTietHoaDon ct ON hd.Id = ct.MaHoaDon
    WHERE hd.MaBan = @idBan AND hd.TrangThai = N'Chưa thanh toán'
    GROUP BY hd.Id, hd.NgayLap, b.TenBan, b.ViTri;

    -- Lấy danh sách món ăn chi tiết
    SELECT 
        sp.TenSP,
        ct.DonGia,
        ct.SoLuong,
        ct.ThanhTien
    FROM dbo.HoaDon hd
    JOIN dbo.ChiTietHoaDon ct ON hd.Id = ct.MaHoaDon
    JOIN dbo.SanPham sp ON ct.MaSP = sp.Id
    WHERE hd.MaBan = @idBan AND hd.TrangThai = N'Chưa thanh toán';
END
GO

-- =============================================
-- 2. SP XỬ LÝ THANH TOÁN (QUAN TRỌNG)
-- =============================================
CREATE OR ALTER PROC usp_ThanhToan
    @idBan INT,
    @giamGia DECIMAL(18,2), -- Giá trị nhập vào (số % hoặc số tiền)
    @loaiGiam INT -- 0: Không giảm, 1: Theo %, 2: Theo tiền
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @idHoaDon INT;

        -- 1. Tìm hóa đơn chưa thanh toán của bàn này
        SELECT @idHoaDon = Id
        FROM dbo.HoaDon
        WHERE MaBan = @idBan AND TrangThai = N'Chưa thanh toán';

        IF @idHoaDon IS NULL
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- 2. Tính lại tổng tiền gốc từ chi tiết (để đảm bảo chính xác tuyệt đối)
        DECLARE @tongTienGoc DECIMAL(18,2) = 0;
        SELECT @tongTienGoc = SUM(ThanhTien)
        FROM dbo.ChiTietHoaDon
        WHERE MaHoaDon = @idHoaDon;

        -- 3. Cập nhật hóa đơn dựa trên loại giảm giá
        -- Lưu ý: Cập nhật 1 cột > 0, cột còn lại phải = 0 để thỏa mãn ràng buộc CHECK trong DB
        IF @loaiGiam = 1 -- Giảm theo %
        BEGIN
            UPDATE dbo.HoaDon
            SET TrangThai = N'Đã thanh toán',
                TongTien = @tongTienGoc,
                GiamGiaPhanTram = @giamGia,
                GiamGiaTien = 0
            WHERE Id = @idHoaDon;
        END
        ELSE IF @loaiGiam = 2 -- Giảm theo tiền mặt
        BEGIN
            UPDATE dbo.HoaDon
            SET TrangThai = N'Đã thanh toán',
                TongTien = @tongTienGoc,
                GiamGiaPhanTram = 0,
                GiamGiaTien = @giamGia
            WHERE Id = @idHoaDon;
        END
        ELSE -- Không giảm
        BEGIN
            UPDATE dbo.HoaDon
            SET TrangThai = N'Đã thanh toán',
                TongTien = @tongTienGoc,
                GiamGiaPhanTram = 0,
                GiamGiaTien = 0
            WHERE Id = @idHoaDon;
        END

        -- Lưu ý: Trigger 'trg_CapNhatTrangThaiBan' (đã tạo trước đó) 
        -- sẽ tự động bắt sự kiện UPDATE này để chuyển trạng thái bàn về 'Còn trống'.

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

-- Store Procedure lấy toàn bộ thông tin cần thiết để tạo hóa đơn tạm 
CREATE OR ALTER PROC usp_InHoaDon
@idBan INT
AS
BEGIN
    SELECT 
        hd.Id AS MaHoaDon,
        hd.NgayLap AS GioVao,
        GETDATE() AS GioRa,
        b.TenBan,
        b.ViTri AS KhuVuc,
        nv.HoTen AS ThuNgan,
        sp.TenSP AS TenMon,
        ct.DonGia,
        ct.SoLuong,
        ct.ThanhTien,
        hd.TongTien AS TongTienGoc,       -- Tổng tiền chưa giảm
        hd.GiamGiaPhanTram,               -- % giảm giá
        hd.GiamGiaTien,                   -- Tiền giảm trực tiếp
        hd.ThanhTienSauGiam AS TongThanhToan -- Số tiền khách phải trả cuối cùng
    FROM dbo.HoaDon hd
    JOIN dbo.Ban b ON hd.MaBan = b.Id
    JOIN dbo.NhanVien nv ON hd.NguoiLap = nv.Id
    JOIN dbo.ChiTietHoaDon ct ON hd.Id = ct.MaHoaDon
    JOIN dbo.SanPham sp ON ct.MaSP = sp.Id
    WHERE hd.MaBan = @idBan AND hd.TrangThai = N'Chưa thanh toán'
END
GO