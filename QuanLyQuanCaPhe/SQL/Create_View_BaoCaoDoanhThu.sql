-- =============================================
-- Script t?o View h? tr? báo cáo doanh thu
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
WHERE hd.TrangThai = N'?ã thanh toán'
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
WHERE hd.TrangThai = N'?ã thanh toán'
GROUP BY YEAR(hd.NgayLap), MONTH(hd.NgayLap);
GO

-- View: L?ch s? báo cáo ?ã l?u
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

-- View: T?ng h?p doanh thu theo nhân viên l?p báo cáo
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

-- Stored Procedure: L?y báo cáo doanh thu theo kho?ng th?i gian
IF OBJECT_ID('sp_GetBaoCaoDoanhThu', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetBaoCaoDoanhThu;
GO

CREATE PROCEDURE sp_GetBaoCaoDoanhThu
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Ki?m tra ngày h?p l?
    IF @TuNgay > @DenNgay
    BEGIN
        RAISERROR('Ngày b?t ??u ph?i nh? h?n ho?c b?ng ngày k?t thúc', 16, 1);
        RETURN;
    END
  
    -- L?y d? li?u doanh thu
    SELECT 
        CAST(hd.NgayLap AS DATE) AS Ngay,
        COUNT(DISTINCT hd.Id) AS SoHoaDon,
    SUM(hd.TongTien) AS DoanhThu
    FROM HoaDon hd
    WHERE hd.NgayLap >= @TuNgay 
  AND hd.NgayLap <= @DenNgay
     AND hd.TrangThai = N'?ã thanh toán'
    GROUP BY CAST(hd.NgayLap AS DATE)
    ORDER BY Ngay;
END
GO

-- Stored Procedure: L?u báo cáo doanh thu
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
        
        -- Ki?m tra ngày h?p l?
        IF @TuNgay > @DenNgay
        BEGIN
 RAISERROR('Ngày b?t ??u ph?i nh? h?n ho?c b?ng ngày k?t thúc', 16, 1);
            RETURN;
        END
        
        -- Ki?m tra nhân viên t?n t?i
  IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE Id = @NguoiLap)
        BEGIN
     RAISERROR('Nhân viên không t?n t?i', 16, 1);
       RETURN;
        END
  
  -- Thêm báo cáo m?i
        INSERT INTO BaoCao_DoanhThu (TuNgay, DenNgay, TongDoanhThu, NguoiLap)
  VALUES (@TuNgay, @DenNgay, @TongDoanhThu, @NguoiLap);
   
      SET @BaoCaoId = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
        
   SELECT @BaoCaoId AS BaoCaoId, 'L?u báo cáo thành công' AS Message;
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
PRINT '=== Testing Views ===';
PRINT 'View v_BaoCao_DoanhThuTheoNgay created successfully';
PRINT 'View v_BaoCao_DoanhThuTheoThang created successfully';
PRINT 'View v_LichSuBaoCaoDoanhThu created successfully';
PRINT 'View v_ThongKeBaoCaoTheoNhanVien created successfully';
PRINT 'Stored Procedure sp_GetBaoCaoDoanhThu created successfully';
PRINT 'Stored Procedure sp_LuuBaoCaoDoanhThu created successfully';
PRINT '=== All objects created successfully ===';
GO
