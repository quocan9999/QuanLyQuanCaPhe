CREATE PROC usp_GetTableList
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