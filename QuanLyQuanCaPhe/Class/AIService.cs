using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Class
{
    public class AIService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // Lấy tại: https://makersuite.google.com/app/apikey
        private const string GEMINI_API_KEY = "AIzaSyC8TxTKmESTXIQo7YKBpdGfsHHuEU65Z-I";

        // Gemini API endpoint
        private const string API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

        /// <summary>
        /// Gọi Gemini API để gợi ý món ăn (Async)
        /// </summary>
        public static async Task<string> GetAISuggestionAsync(string userMessage, string mode)
        {
            try
            {
                // 1. Lấy dữ liệu từ database
                string context = BuildContextFromDatabase(mode);

                // 2. Tạo prompt dựa trên mode
                string systemPrompt = BuildSystemPrompt(mode, context);

                // 3. Kết hợp system prompt + user message
                string fullPrompt = systemPrompt + "\n\nCÂU HỎI CỦA NHÂN VIÊN: " + userMessage;

                // 4. Tạo request body theo format của Gemini
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = fullPrompt }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.7,
                        topK = 40,
                        topP = 0.95,
                        maxOutputTokens = 2048,
                        stopSequences = new string[] { }
                    },
                    safetySettings = new[]
                    {
                        new { category = "HARM_CATEGORY_HARASSMENT", threshold = "BLOCK_MEDIUM_AND_ABOVE" },
                        new { category = "HARM_CATEGORY_HATE_SPEECH", threshold = "BLOCK_MEDIUM_AND_ABOVE" },
                        new { category = "HARM_CATEGORY_SEXUALLY_EXPLICIT", threshold = "BLOCK_MEDIUM_AND_ABOVE" },
                        new { category = "HARM_CATEGORY_DANGEROUS_CONTENT", threshold = "BLOCK_MEDIUM_AND_ABOVE" }
                    }
                };

                // 5. Serialize request
                string jsonRequest = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // 6. Gửi request tới Gemini API
                string urlWithKey = $"{API_URL}?key={GEMINI_API_KEY}";
                HttpResponseMessage response = await httpClient.PostAsync(urlWithKey, content);

                // 7. Đọc response
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // 8. Kiểm tra lỗi HTTP
                if (!response.IsSuccessStatusCode)
                {
                    return $"❌ Lỗi API (HTTP {response.StatusCode}): {jsonResponse}";
                }

                // 9. Parse response từ Gemini
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    // Gemini response format: 
                    // { "candidates": [{ "content": { "parts": [{ "text": "..." }] } }] }

                    if (doc.RootElement.TryGetProperty("candidates", out JsonElement candidates))
                    {
                        if (candidates.GetArrayLength() > 0)
                        {
                            var firstCandidate = candidates[0];
                            if (firstCandidate.TryGetProperty("content", out JsonElement contentElement))
                            {
                                if (contentElement.TryGetProperty("parts", out JsonElement parts))
                                {
                                    if (parts.GetArrayLength() > 0)
                                    {
                                        var firstPart = parts[0];
                                        if (firstPart.TryGetProperty("text", out JsonElement textElement))
                                        {
                                            return textElement.GetString();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Nếu có lỗi trong response
                    if (doc.RootElement.TryGetProperty("error", out JsonElement error))
                    {
                        if (error.TryGetProperty("message", out JsonElement errorMessage))
                        {
                            return $"❌ Lỗi từ Gemini: {errorMessage.GetString()}";
                        }
                    }
                }

                return "❌ Không nhận được phản hồi hợp lệ từ AI.";
            }
            catch (HttpRequestException ex)
            {
                return $"❌ Lỗi kết nối mạng: {ex.Message}\n\nKiểm tra:\n- Kết nối internet\n- API Key có đúng không\n- Đã bật Gemini API chưa";
            }
            catch (JsonException ex)
            {
                return $"❌ Lỗi parse JSON: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi không xác định: {ex.Message}";
            }
        }

        /// <summary>
        /// Xây dựng context từ database dựa trên mode
        /// </summary>
        private static string BuildContextFromDatabase(string mode)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                switch (mode)
                {
                    case "Gợi ý theo bối cảnh":
                        sb.AppendLine("=== DANH SÁCH SẢN PHẨM PHỔ BIẾN ===");
                        string querySP = @"
                            SELECT TOP 5 sp.TenSP, sp.Gia, dm.TenDM, sp.DVT
                            FROM SanPham sp
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            WHERE sp.TrangThai = N'Còn'
                            ORDER BY sp.Id DESC";

                        DataTable dtSP = DataProvider.Instance.ExecuteQuery(querySP);
                        string currentCategory = "";

                        foreach (DataRow row in dtSP.Rows)
                        {
                            string category = row["TenDM"].ToString();
                            if (category != currentCategory)
                            {
                                sb.AppendLine($"\n📂 {category}:");
                                currentCategory = category;
                            }
                            sb.AppendLine($"   - {row["TenSP"]}: {Convert.ToDecimal(row["Gia"]):N0}đ/{row["DVT"]}");
                        }
                        break;

                    case "Món bán chạy nhất":
                        sb.AppendLine("=== TOP 8 MÓN BÁN CHẠY (30 NGÀY GẦN NHẤT) ===");
                        string queryBanChay = @"
                            SELECT TOP 8
                                sp.TenSP,
                                sp.Gia,
                                dm.TenDM,
                                SUM(cthd.SoLuong) AS TongSoLuong,
                                SUM(cthd.ThanhTien) AS DoanhThu
                            FROM ChiTietHoaDon cthd
                            INNER JOIN HoaDon hd ON cthd.IdHoaDon = hd.Id
                            INNER JOIN SanPham sp ON cthd.IdSanPham = sp.Id
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            WHERE hd.NgayVao >= DATEADD(DAY, -30, GETDATE())
                              AND hd.TrangThai = N'Đã thanh toán'
                            GROUP BY sp.TenSP, sp.Gia, dm.TenDM
                            ORDER BY TongSoLuong DESC";

                        DataTable dtBanChay = DataProvider.Instance.ExecuteQuery(queryBanChay);

                        foreach (DataRow row in dtBanChay.Rows)
                        {
                            sb.AppendLine($"   {row["TenSP"]} ({row["TenDM"]}): " +
                                        $"{Convert.ToDecimal(row["Gia"]):N0}đ - " +
                                        $"Bán {row["TongSoLuong"]} phần");
                        }
                        break;

                    case "Món lợi nhuận cao":
                        sb.AppendLine("=== TOP 8 MÓN LỢI NHUẬN CAO ===");
                        string queryLoiNhuan = @"
                            SELECT TOP 8
                                sp.TenSP,
                                sp.Gia,
                                dm.TenDM,
                                SUM(cthd.ThanhTien) AS DoanhThu
                            FROM ChiTietHoaDon cthd
                            INNER JOIN HoaDon hd ON cthd.IdHoaDon = hd.Id
                            INNER JOIN SanPham sp ON cthd.IdSanPham = sp.Id
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            WHERE hd.NgayVao >= DATEADD(DAY, -30, GETDATE())
                              AND hd.TrangThai = N'Đã thanh toán'
                            GROUP BY sp.TenSP, sp.Gia, dm.TenDM
                            ORDER BY DoanhThu DESC";

                        DataTable dtLoiNhuan = DataProvider.Instance.ExecuteQuery(queryLoiNhuan);

                        foreach (DataRow row in dtLoiNhuan.Rows)
                        {
                            sb.AppendLine($"   {row["TenSP"]} ({row["TenDM"]}): " +
                                        $"{Convert.ToDecimal(row["Gia"]):N0}đ - " +
                                        $"Doanh thu {Convert.ToDecimal(row["DoanhThu"]):N0}đ");
                        }
                        break;

                    case "Món theo thời gian":
                        int currentHour = DateTime.Now.Hour;
                        string timeOfDay = "";
                        List<string> recommendations = new List<string>();

                        if (currentHour >= 6 && currentHour < 11)
                        {
                            timeOfDay = "BUỔI SÁNG (6h-11h)";
                            recommendations.AddRange(new[] { "cafe", "bánh mì", "trà", "sandwich" });
                        }
                        else if (currentHour >= 11 && currentHour < 14)
                        {
                            timeOfDay = "BUỔI TRƯA (11h-14h)";
                            recommendations.AddRange(new[] { "cơm", "mì", "phở", "bún" });
                        }
                        else if (currentHour >= 14 && currentHour < 18)
                        {
                            timeOfDay = "BUỔI CHIỀU (14h-18h)";
                            recommendations.AddRange(new[] { "cafe", "trà", "bánh ngọt", "sinh tố" });
                        }
                        else
                        {
                            timeOfDay = "BUỔI TỐI (18h-23h)";
                            recommendations.AddRange(new[] { "cơm", "lẩu", "nướng", "bia" });
                        }

                        sb.AppendLine($"⏰ THỜI GIAN HIỆN TẠI: {timeOfDay}");

                        // Lấy món phù hợp theo thời gian
                        string queryTheoGio = @"
                            SELECT TOP 8 sp.TenSP, sp.Gia, dm.TenDM
                            FROM SanPham sp
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            WHERE sp.TrangThai = N'Còn'
                            ORDER BY sp.Id DESC";

                        DataTable dtTG = DataProvider.Instance.ExecuteQuery(queryTheoGio);
                        sb.AppendLine("💡 GỢI Ý THEO THỜI GIAN:");

                        foreach (string keyword in recommendations)
                        {
                            var matchingProducts = dtTG.AsEnumerable()
                                .Where(r => r["TenSP"].ToString().ToLower().Contains(keyword.ToLower()) ||
                                           r["TenDM"].ToString().ToLower().Contains(keyword.ToLower()))
                                .Take(2); // Giảm từ 3 xuống 2 món

                            foreach (var product in matchingProducts)
                            {
                                sb.AppendLine($"   ✓ {product["TenSP"]} ({product["TenDM"]}): {Convert.ToDecimal(product["Gia"]):N0}đ");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"\n⚠️ Lỗi lấy dữ liệu: {ex.Message}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Xây dựng system prompt cho AI
        /// </summary>
        private static string BuildSystemPrompt(string mode, string context)
        {
            string basePrompt = @"Bạn là trợ lý AI thông minh của quán cà phê tại Việt Nam. 
                Nhiệm vụ: Gợi ý món ăn/uống phù hợp cho nhân viên tư vấn khách hàng.

                QUY TẮC QUAN TRỌNG:
                1. Trả lời NGẮN GỌN, tối đa 4-5 câu (không dài dòng)
                2. Gợi ý CỤ THỂ 2-3 món có trong menu với LÝ DO
                3. Dùng emoji phù hợp (☕🥐🍰🥤🍜)
                4. Nói theo ngôi thứ nhất ""Tôi gợi ý...""
                5. Kết thúc bằng câu hỏi ngắn để tương tác
                6. Ưu tiên món CÓ TRONG DANH SÁCH dưới đây
                7. Nếu không có món phù hợp, gợi ý món TƯƠNG TỰ
                8. Luôn kèm GIÁ khi gợi ý món

                DỮ LIỆU HIỆN TẠI CỦA QUÁN:
                " + context + @"

                PHONG CÁCH TRẢ LỜI MẪU:
                - Tôi gợi ý [Món 1] và [Món 2] vì [lý do ngắn gọn]. [Giá cả]. Bạn cần tư vấn thêm không?
                - Với [bối cảnh], món [A] ([giá]) và [B] ([giá]) sẽ phù hợp nhất. Khách có sở thích gì đặc biệt không?

                TUYỆT ĐỐI KHÔNG:
                - Gợi ý món không có trong danh sách
                - Viết quá dài, quá chi tiết
                - Dùng ngôn ngữ quá trang trọng/văn chương";

            return basePrompt;
        }

        /// <summary>
        /// Phương thức đồng bộ (wrapper cho async)
        /// </summary>
        public static string GetAISuggestion(string userMessage, string mode)
        {
            try
            {
                return Task.Run(() => GetAISuggestionAsync(userMessage, mode)).Result;
            }
            catch (AggregateException ex)
            {
                // Unwrap inner exception
                return $"❌ Lỗi: {ex.InnerException?.Message ?? ex.Message}";
            }
        }

        /// <summary>
        /// Kiểm tra API key có hợp lệ không
        /// </summary>
        public static async Task<bool> TestAPIKeyAsync()
        {
            try
            {
                var testBody = new
                {
                    contents = new[]
                    {
                        new { parts = new[] { new { text = "Hello" } } }
                    }
                };

                string jsonRequest = JsonSerializer.Serialize(testBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                string urlWithKey = $"{API_URL}?key={GEMINI_API_KEY}";
                HttpResponseMessage response = await httpClient.PostAsync(urlWithKey, content);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Test API key (sync version)
        /// </summary>
        public static bool TestAPIKey()
        {
            return Task.Run(() => TestAPIKeyAsync()).Result;
        }
    }
}