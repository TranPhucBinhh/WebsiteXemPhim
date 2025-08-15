# WebsiteMovie_DAN
Create Website Watching Movie with ASP.NET MVC + Database SQL Server
# 🎬 WebsiteXemPhim — Ứng dụng xem phim (ASP.NET MVC)

> Nền tảng xem phim trực tuyến: duyệt danh mục, xem trailer/phim, đánh giá, bình luận, danh sách yêu thích, quản trị nội dung.  
> Tập trung vào tính năng và hướng dẫn kỹ thuật.
> Thi triển code theo các mẫu thiết kế của phần mềm
> Sử dụng đồ án mẫu để thi triển, phát triển code tiêu chuẩn thành code theo các mẫu thiết kế(Singgleton,Facade, Strategy,... )

---

## ✨ Tính năng chính

- 👀 **Duyệt & tìm kiếm**: theo tên phim, thể loại, năm, quốc gia
- 🏷️ **Bộ lọc nâng cao**: thể loại, rating, thời lượng, tình trạng 
- 🎞️ **Xem trailer/phim**: player HTML5, hỗ trợ phụ đề
- ⭐ **Đánh giá & bình luận**: người dùng chấm sao, viết review, like/dislike.
- 📌 **Danh sách yêu thích/Watchlist**: thêm/xoá nhanh, đồng bộ theo tài khoản.
- 👤 **Tài khoản & phân quyền**: Đăng ký/Đăng nhập, Admin/Người dùng
- 🛠️ **Quản trị nội dung**: CRUD phim, tập, thể loại, diễn viên, banner, phụ đề; duyệt/ẩn review của người dùng.
- ⏱️ **Lịch sử xem & tiếp tục**: ghi nhớ tiến độ (progress) từng tập/phim.
- 📈 **Báo cáo**: lượt xem theo ngày/tháng, phim thịnh hành, top tìm kiếm.

---

## 🧱 Kiến trúc & Công nghệ

- **Web**: ASP.NET Core MVC **(khuyến nghị)** hoặc ASP.NET MVC 5.
- **ORM**: Entity Framework Core/EF6 (Code First).
- **CSDL**: SQL Server (hoặc PostgreSQL/MySQL).
- **UI**: Razor Views, Bootstrap/Tailwind, jQuery/AlpineJS.
- **Xác thực**: ASP.NET Identity / External OAuth (Google/Microsoft — tuỳ chọn).
- **Media**: Lưu file tĩnh (wwwroot) / Blob Storage; streaming HLS/DASH qua Nginx/Media Server (tuỳ chọn).
- **Ghi log**: Serilog, Application Insights (tuỳ chọn).

### Hướng dẫn chạy

1. Mở solution bằng **Visual Studio 2022**
2. Kết nối database với SQL Server
3. Chỉnh `connectionStrings` trong `web.config`  
4. Chạy file index

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDb;Integrated Security=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```


## 🔐 Seed dữ liệu & tài khoản để chạy

- Tạo `DbInitializer/SeedData` sinh phim mẫu, thể loại, người nổi tiếng, 3–5 tập.
- Đăng nhập tk:  
  - **Admin**: `admin` / `123456`

---

## 📬 Liên hệ

- Tác giả: Trần Phúc Bình
- Email: tranphucbinh201@gmail.com
