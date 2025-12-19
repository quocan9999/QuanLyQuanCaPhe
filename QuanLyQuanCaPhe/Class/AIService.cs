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
        private const string API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent";

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
                        maxOutputTokens = 500,
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
                    case "🎯 Gợi ý theo bối cảnh":
                        // Lấy thông tin toàn bộ sản phẩm
                        sb.AppendLine("=== DANH SÁCH SẢN PHẨM CỦA QUÁN ===");
                        string querySP = @"
                            SELECT sp.TenSP, sp.Gia, dm.TenDM, sp.DVT
                            FROM SanPham sp
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            WHERE sp.TrangThai = N'Còn'
                            ORDER BY dm.TenDM, sp.TenSP";

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

                    case "📊 Món bán chạy nhất":
                        // Lấy top 10 món bán chạy trong 30 ngày gần nhất
                        sb.AppendLine("=== TOP 10 MÓN BÁN CHẠY (30 NGÀY GẦN NHẤT) ===");
                        string queryBC = @"
                            SELECT TOP 10 
                                sp.TenSP, 
                                dm.TenDM,
                                SUM(cthd.SoLuong) AS TongSoLuong, 
                                SUM(cthd.ThanhTien) AS TongDoanhThu,
                                COUNT(DISTINCT cthd.IdHoaDon) AS SoLanGoi
                            FROM ChiTietHoaDon cthd
                            INNER JOIN SanPham sp ON cthd.IdSanPham = sp.Id
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            INNER JOIN HoaDon hd ON cthd.IdHoaDon = hd.Id
                            WHERE hd.TrangThai = N'Đã thanh toán'
                                AND hd.NgayVao >= DATEADD(DAY, -30, GETDATE())
                            GROUP BY sp.TenSP, dm.TenDM
                            ORDER BY TongSoLuong DESC";

                        DataTable dtBC = DataProvider.Instance.ExecuteQuery(queryBC);
                        int rank = 1;

                        foreach (DataRow row in dtBC.Rows)
                        {
                            string medal = rank == 1 ? "🥇" : rank == 2 ? "🥈" : rank == 3 ? "🥉" : $"#{rank}";
                            sb.AppendLine($"{medal} {row["TenSP"]} ({row["TenDM"]})");
                            sb.AppendLine($"    • Số lượng bán: {row["TongSoLuong"]} phần");
                            sb.AppendLine($"    • Doanh thu: {Convert.ToDecimal(row["TongDoanhThu"]):N0}đ");
                            sb.AppendLine($"    • Được gọi: {row["SoLanGoi"]} lần\n");
                            rank++;
                        }

                        if (dtBC.Rows.Count == 0)
                        {
                            sb.AppendLine("(Chưa có dữ liệu bán hàng trong 30 ngày qua)");
                        }
                        break;

                    case "💰 Món lợi nhuận cao":
                        // Lấy món có giá cao và phân tích
                        sb.AppendLine("=== MÓN GIÁ CAO - LỢI NHUẬN TỐT ===");
                        string queryGiaCao = @"
                            SELECT TOP 15 
                                sp.TenSP, 
                                sp.Gia, 
                                dm.TenDM,
                                ISNULL(SUM(cthd.SoLuong), 0) AS DaBan
                            FROM SanPham sp
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            LEFT JOIN ChiTietHoaDon cthd ON sp.Id = cthd.IdSanPham
                            LEFT JOIN HoaDon hd ON cthd.IdHoaDon = hd.Id 
                                AND hd.TrangThai = N'Đã thanh toán'
                                AND hd.NgayVao >= DATEADD(DAY, -30, GETDATE())
                            WHERE sp.TrangThai = N'Còn'
                            GROUP BY sp.TenSP, sp.Gia, dm.TenDM
                            ORDER BY sp.Gia DESC";

                        DataTable dtGC = DataProvider.Instance.ExecuteQuery(queryGiaCao);

                        foreach (DataRow row in dtGC.Rows)
                        {
                            decimal gia = Convert.ToDecimal(row["Gia"]);
                            int daBan = Convert.ToInt32(row["DaBan"]);
                            string popularity = daBan > 50 ? "🔥 Rất phổ biến" :
                                               daBan > 20 ? "✨ Phổ biến" :
                                               daBan > 0 ? "💡 Ít người biết" : "🆕 Chưa bán";

                            sb.AppendLine($"💎 {row["TenSP"]} ({row["TenDM"]})");
                            sb.AppendLine($"    • Giá: {gia:N0}đ - {popularity}");
                            if (daBan > 0)
                            {
                                sb.AppendLine($"    • Đã bán: {daBan} phần (30 ngày)\n");
                            }
                            else
                            {
                                sb.AppendLine($"    • Món mới hoặc chưa có khách thử\n");
                            }
                        }
                        break;

                    case "⏰ Món theo thời gian":
                        // Phân tích theo giờ hiện tại
                        DateTime now = DateTime.Now;
                        int hour = now.Hour;
                        string timeContext = "";
                        string[] recommendations;

                        if (hour >= 6 && hour < 11)
                        {
                            timeContext = "🌅 BUỔI SÁNG (6h-11h)";
                            recommendations = new[] { "Cà phê phin", "Bạc xỉu", "Cà phê sữa", "Bánh mì", "Sandwich", "Trứng", "Sữa chua" };
                        }
                        else if (hour >= 11 && hour < 14)
                        {
                            timeContext = "☀️ BUỔI TRƯA (11h-14h)";
                            recommendations = new[] { "Cơm", "Bún", "Phở", "Nước ép", "Trà đá", "Sinh tố", "Món ăn nhanh" };
                        }
                        else if (hour >= 14 && hour < 18)
                        {
                            timeContext = "🌤️ BUỔI CHIỀU (14h-18h)";
                            recommendations = new[] { "Cà phê", "Trà sữa", "Bánh ngọt", "Kem", "Nước trái cây", "Smoothie" };
                        }
                        else
                        {
                            timeContext = "🌙 BUỔI TỐI (18h-22h)";
                            recommendations = new[] { "Trà sữa", "Sinh tố", "Nước ép", "Món nhẹ", "Dessert", "Cocktail không cồn" };
                        }

                        sb.AppendLine($"=== {timeContext} ===");
                        sb.AppendLine($"Thời gian hiện tại: {now:HH:mm}, {now:dddd, dd/MM/yyyy}\n");

                        // Lấy món phù hợp với thời gian
                        string queryTheoGio = @"
                            SELECT sp.TenSP, sp.Gia, dm.TenDM
                            FROM SanPham sp
                            INNER JOIN DanhMuc dm ON sp.IdDanhMuc = dm.Id
                            WHERE sp.TrangThai = N'Còn'
                            ORDER BY sp.TenSP";

                        DataTable dtTG = DataProvider.Instance.ExecuteQuery(queryTheoGio);
                        sb.AppendLine("💡 GỢI Ý THEO THỜI GIAN:");

                        foreach (string keyword in recommendations)
                        {
                            var matchingProducts = dtTG.AsEnumerable()
                                .Where(r => r["TenSP"].ToString().ToLower().Contains(keyword.ToLower()) ||
                                           r["TenDM"].ToString().ToLower().Contains(keyword.ToLower()))
                                .Take(3);

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