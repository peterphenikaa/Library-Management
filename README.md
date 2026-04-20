# Hệ Thống Quản Lý Thư Viện (Library Management System)

## 1. Giới thiệu đề tài
Trong thời đại công nghệ thông tin phát triển, việc quản lý thư viện bằng phương pháp thủ công không còn phù hợp do gặp nhiều hạn chế như:
- Khó khăn trong việc lưu trữ và tìm kiếm dữ liệu.
- Dễ xảy ra sai sót khi ghi chép.
- Tốn thời gian xử lý mượn/trả sách.

Vì vậy, dự án **"Xây dựng hệ thống quản lý thư viện"** được thực hiện nhằm tin học hóa quy trình quản lý, nâng cao hiệu quả và độ chính xác cho hoạt động của thư viện.

## 2. Mục tiêu dự án
Hệ thống được xây dựng với các mục tiêu chính:
- **Quản lý thông tin sách:** Lưu trữ, phân loại và cập nhật trạng thái sách trong thư viện.
- **Quản lý thông tin độc giả:** Theo dõi hồ sơ, thông tin liên lạc và lịch sử hoạt động của người dùng.
- **Hỗ trợ mượn và trả sách:** Rút ngắn thời gian, tăng cường tính minh bạch và chính xác trong khâu lưu thông tài liệu.
- **Tìm kiếm sách nhanh chóng:** Hỗ trợ người dùng tra cứu tài liệu linh hoạt theo nhiều tiêu chí.
- **Thống kê và báo cáo dữ liệu:** Cung cấp cho Ban quản lý (Thủ thư/Admin) cái nhìn tổng quan về tình hình hoạt động của thư viện.

## 3. Chức năng hệ thống & Use Case
Hệ thống được ứng dụng chủ yếu cho thư viện trường học hoặc phòng đọc lưu động quy mô vừa và nhỏ, hoạt động dưới dạng **Web Application**. 

Có 2 nhóm người dùng chính tham gia vào hệ thống (dựa theo lược đồ Use Case): **Admin (Thủ thư/Quản trị viên)** và **User (Độc giả)**.

### 3.1 Chức năng chung (Cả Admin & User có thể thực hiện)
- Đăng nhập (UC1.2)
- Đổi mật khẩu (UC1.3)
- Đăng xuất (UC1.4)
- Tìm kiếm sách theo từ khóa (UC3.1)
- Xem chi tiết sách (UC3.3)

### 3.2 Chức năng dành riêng cho Admin (Thủ thư)
- **Quản lý Sách:** Lập danh mục sách, Thêm sách mới (UC2.1), Chỉnh sửa sách (UC2.2), Xóa sách (UC2.3).
- **Quản lý Người dùng:** Thêm người dùng (Thủ thư/độc giả khác) (UC4.1), Chỉnh sửa người dùng (UC4.2), Khóa/Mở tài khoản (UC4.3).
- **Quản lý Mượn/Trả:** Lập phiếu mượn (UC5.2), Lập phiếu trả (UC5.3), Xử lý vi phạm/phạt trễ hạn, hỏng sách (UC5.4).
- **Thống kê / Báo cáo:** Xem thống kê sách được mượn nhiều nhất (UC6.1), Xem báo cáo hoạt động người dùng (UC6.2).
- **Quản lý hệ thống:** Phân quyền hệ thống (UC6.3).

### 3.3 Chức năng dành riêng cho User (Độc giả)
- **Quản lý tài khoản:** Đăng ký thành viên (UC1.1), Cập nhật thông tin cá nhân (UC1.5).
- **Tương tác Sách thư viện:** Lọc sách theo danh mục (UC3.2), Đặt trước sách (UC5.1).
- **Theo dõi cá nhân:** Xem lịch sử mượn/trả sách (UC5.5).

---

## 4. Phân tích Công nghệ & Tech Stack

Dựa vào yêu cầu xây dựng nền tảng Web hiện đại, dự án được lựa chọn sử dụng các công nghệ tiêu chuẩn hiện nay, kết hợp kiến trúc **Frontend - Backend độc lập qua tiêu chuẩn API RESTful**:

### 4.1. Frontend: Next.js + React
- **Framework:** **Next.js 14/15** (React Framework) – Hỗ trợ SSR (Server-Side Rendering) linh hoạt, tối ưu SEO, hiệu năng cực tốt cho các dự án lớn nhỏ.
- **Ngôn ngữ:** TypeScript – Tăng tính ổn định, dễ dàng bảo trì, bắt lỗi logic trong quá trình biên dịch dữ liệu, đặc biệt khi giao tiếp mượt mà với Backend.
- **UI/UX & Styling:** Tailwind CSS kết hợp với các thư viện Component mở như **Shadcn UI** để xây dựng 2 giao diện song song: Dashboard cho Admin và Portal cho Độc giả.
- **State Management / Data Fetching:** Zustand và TanStack Query (React Query) quản lý quá trình gọi và cache dữ liệu API.

### 4.2. Backend: C# ASP.NET Core
Đối với lập trình Backend bằng C#, công nghệ tiêu chuẩn, mạnh mẽ và thông dụng nhất hiện nay chính là phiên bản web của nền tảng .NET:
- **Framework:** **ASP.NET Core 8.0** Web API – Được Microsoft tối ưu về bảo mật và mang lại hiệu suất nằm trong top đầu các Web Backend Framework.
- **Kiến trúc mã nguồn:** Clean Architecture hoặc N-Tier Architecture (Chia lớp như API Component, Business Services, Data Access Repositories).
- **O/RM (Truy xuất CSDL):** **Entity Framework Core (EF Core)** - Công cụ chuẩn hóa lập trình tương tác dữ liệu (sử dụng Code-First Migration).
- **Cơ sở dữ liệu Database:** **SQL Server** - Hệ cơ sở dữ liệu mạnh mẽ của Microsoft luôn đi đôi hoàn hảo cùng C# .NET.
- **Bảo mật / Xác thực:** **JWT (JSON Web Token)** để cấp quyền đăng nhập phi trạng thái kèm theo Authentication Policies phân quyền Roles cụ thể (Role: Admin, Librarian, Member).

---

## 5. Kế hoạch Triển khai Thực hiện Dự án (Development Roadmap)

Để bắt đầu viết code cho toàn bộ dự án, bạn sẽ cần trải qua quy trình thực hiện theo các bước cụ thể:

### Bước 1: Thiết kế Cơ sở Dữ liệu & Khởi tạo Dự Án (DB & Setup)
- Lên sơ đồ ERD (Entity Relationship Diagram) gồm đầy đủ các bảng được trích xuất từ Use Case: `Users`, `Roles`, `Books`, `Categories`, `BorrowTickets`, `BorrowDetails`, `Fines`,...
- Khởi tạo 2 repository / folder code độc lập (Ví dụ: `client` cho Next.js và `api` cho .NET Core).
- Thiết lập cấu trúc cơ bản, cài đặt thư viện cần thiết, Entity Framework kết nối về database qua Connection String.

### Bước 2: Phát triển Backend API với C# (Backend Dev)
Phân đoạn code thành các Domain theo Use Case:
- **Auth Service:** Khởi tạo API Đăng ký, Đăng nhập, trả về Token đăng nhập ứng với từng nhóm user (Admin - User).
- **Book Service:** Viết API quản lý kho (Thêm, Xóa, Sửa sách), API lấy và lọc danh sách đầu sách cho người dùng tra cứu.
- **User Service:** API cho người dùng xem và update hồ sơ cá nhân. API cho Admin xử lý tài khoản, thay đổi quyền hạn.
- **Borrowing Service:** Trái tim dự án = API nghiệp vụ mượn sách. (Quản lý trạng thái từ Khách hàng nhấn Đặt trước sách từ web -> Thủ thư xác nhận lập phiếu mượn -> Lập phiếu trả/kiểm tra phí quá hạn).
- **Reporting Service:** Logic thống kê nhóm theo danh mục số liệu (Lịch sử cá nhân và Cảnh báo của Admin).

### Bước 3: Thiết kế Giao diện Frontend Next.js (Frontend Dev)
Thiết kế song song 2 Web Interface hướng đối tượng:
- **Web App Phía Độc giả (Client Portal):** 
  - Giao diện đăng nhập/đăng ký. 
  - Trang chủ khám phá, Tìm kiếm thư mục Sách mới phát hành. 
  - Cửa sổ trang chi tiết sách nơi thao tác trực tiếp nút chức năng "Mượn / Đặt trước". 
  - Quản lý Hồ sơ tài khoản > Tab Lịch sử lịch mượn/trả.
- **Web App Trang Quản Trị (Admin Dashboard):**
  - Trang báo cáo trực quan có biểu đồ. 
  - Phân hệ QL Danh mục sách (Table grid, Form Upload bìa sách, số lượng kho).
  - Phân hệ QL Hội viên Độc giả.
  - Phân hệ Duyệt / Xử lý hồ sơ mượn từ các ticket do users online gửi lên, hoặc tự lập phiếu tay (Manual ticket creation) cho người đến mượn sách trực tiếp tại trường.

### Bước 4: Tích hợp Dữ liệu & Testing (Integration)
- Gắn kết (Call API Fetch) Frontend bằng giao thức HTTP, đổ dữ liệu UI ra từ hệ nguồn Backend.
- Xử lý các luồng thông báo lỗi người dùng (Toast Notify) khi sai pass, khi đặt mượn quyển sách đã cạn số lượng kho, vv.
- Testing kỹ các logic liên quan tới mượn quá hạn để tính tiền phạt chuẩn xác.

### Bước 5: Đóng gói và Đưa Lên Mạng (Deployment)
- Thiết lập biến môi trường production `.env`.
- Deploy Backend (.NET API) lên Azure App Service / AWS / Render.
- Deploy hệ quản trị SQL Database lên cloud database instance riêng biệt hoặc chung host.
- Build Next.js và push trực tiếp lên host platform cực tốt của chính Vercel.
- Cấu hình domain, chốt sản phẩm bàn giao báo cáo.