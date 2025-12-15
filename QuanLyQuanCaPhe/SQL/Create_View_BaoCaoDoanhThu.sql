-- =============================================
-- Script tạo view hỗ trợ báo cáo doanh thu
-- =============================================

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

-- Test Views
PRINT N'=== Kiểm thử các view ===';
PRINT N'View v_BaoCao_DoanhThuTheoNgay đã được tạo thành công';
PRINT N'View v_BaoCao_DoanhThuTheoThang đã được tạo thành công';
PRINT N'View v_LichSuBaoCaoDoanhThu đã được tạo thành công';
PRINT N'View v_ThongKeBaoCaoTheoNhanVien đã được tạo thành công';
PRINT N'Stored Procedure sp_GetBaoCaoDoanhThu đã được tạo thành công';
PRINT N'Stored Procedure sp_LuuBaoCaoDoanhThu đã được tạo thành công';
PRINT N'=== Tất cả các đối tượng đã được tạo thành công ===';
GO