# 📋 Danh sách chức năng hệ thống

## Phần 5: Hiện thực (Thiết kế hệ thống, phần mềm)

Dưới đây là danh sách các chức năng của hệ thống Quản lý Quán Cà Phê được sắp xếp theo thứ tự logic:

---

### 🔐 Nhóm 1: Xác thực và Phân quyền
1. **Chức năng đăng nhập** - Xác thực người dùng với tên đăng nhập và mật khẩu, phân quyền Admin/Nhân viên

### 👤 Nhóm 2: Quản lý thông tin cá nhân
2. **Chức năng xem thông tin cá nhân** - Nhân viên xem và cập nhật thông tin tài khoản cá nhân

### 🗂️ Nhóm 3: Quản lý danh mục dữ liệu
3. **Chức năng quản lý danh mục sản phẩm** - Thêm, sửa, xóa các danh mục (Cà phê, Trà, Nước ép, Bánh ngọt,...)
4. **Chức năng quản lý sản phẩm (món)** - Thêm, sửa, xóa thông tin các món đồ uống và thức ăn
5. **Chức năng quản lý bàn** - Thêm, sửa, xóa thông tin các bàn trong quán, quản lý theo khu vực
6. **Chức năng quản lý tài khoản** - Thêm, sửa, xóa tài khoản người dùng hệ thống (chỉ Admin)

### 🛒 Nhóm 4: Nghiệp vụ bán hàng
7. **Chức năng mở bàn** - Tạo hóa đơn mới khi khách hàng đến
8. **Chức năng đặt món (Order)** - Thêm món vào hóa đơn của bàn đang phục vụ
9. **Chức năng sửa số lượng món** - Cập nhật số lượng món trong hóa đơn
10. **Chức năng xóa món khỏi hóa đơn** - Xóa món đã đặt khỏi hóa đơn
11. **Chức năng chuyển bàn** - Chuyển hóa đơn từ bàn này sang bàn khác
12. **Chức năng hủy hóa đơn** - Hủy toàn bộ hóa đơn của bàn

### 💳 Nhóm 5: Thanh toán
13. **Chức năng thanh toán** - Xử lý thanh toán hóa đơn với hỗ trợ áp dụng giảm giá
14. **Chức năng in hóa đơn** - Xuất và in hóa đơn sử dụng Crystal Reports

### 📊 Nhóm 6: Báo cáo thống kê
15. **Chức năng báo cáo doanh thu** - Thống kê doanh thu theo khoảng thời gian (ngày, tuần, tháng)
16. **Chức năng báo cáo món bán chạy** - Xem danh sách các sản phẩm bán chạy nhất

### 🤖 Nhóm 7: Tích hợp AI
17. **Chức năng gợi ý món ăn bằng AI** - Sử dụng trí tuệ nhân tạo để gợi ý món ăn/đồ uống phù hợp dựa trên sở thích khách hàng và các món bán chạy

### 🚪 Nhóm 8: Khác
18. **Chức năng đăng xuất** - Thoát khỏi hệ thống và quay về màn hình đăng nhập

---

## 📝 Tóm tắt

| STT | Chức năng | Mô tả ngắn |
|-----|-----------|------------|
| 1 | Đăng nhập | Xác thực và phân quyền người dùng |
| 2 | Xem thông tin cá nhân | Xem/cập nhật thông tin tài khoản |
| 3 | Quản lý danh mục sản phẩm | CRUD danh mục |
| 4 | Quản lý sản phẩm (món) | CRUD sản phẩm |
| 5 | Quản lý bàn | CRUD bàn theo khu vực |
| 6 | Quản lý tài khoản | CRUD tài khoản (Admin) |
| 7 | Mở bàn | Tạo hóa đơn mới |
| 8 | Đặt món (Order) | Thêm món vào hóa đơn |
| 9 | Sửa số lượng món | Cập nhật số lượng |
| 10 | Xóa món khỏi hóa đơn | Xóa món đã đặt |
| 11 | Chuyển bàn | Chuyển hóa đơn giữa các bàn |
| 12 | Hủy hóa đơn | Hủy toàn bộ hóa đơn |
| 13 | Thanh toán | Xử lý thanh toán + giảm giá |
| 14 | In hóa đơn | Xuất hóa đơn Crystal Reports |
| 15 | Báo cáo doanh thu | Thống kê doanh thu |
| 16 | Báo cáo món bán chạy | Top sản phẩm bán chạy |
| 17 | Gợi ý món ăn bằng AI | AI gợi ý món phù hợp |
| 18 | Đăng xuất | Thoát hệ thống |

---

**Tổng cộng: 18 chức năng**
