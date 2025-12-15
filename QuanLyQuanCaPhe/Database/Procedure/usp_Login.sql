CREATE OR ALTER PROC usp_Login
@userName NVARCHAR(100), @passWord NVARCHAR(1000)
AS
BEGIN
	SELECT 
		TenDangNhap,
		VaiTro,
		NgayTao,
		TrangThai
	FROM dbo.NguoiDung 
	WHERE TenDangNhap = @userName 
	  AND MatKhau = @passWord 
	  AND TrangThai = N'Hoạt động'
END
GO