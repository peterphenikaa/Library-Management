# Hệ Thống Quản Lý Thư Viện

## CHƯƠNG II. PHÂN TÍCH HỆ THỐNG

### 2. Chức năng hệ thống

#### 2.1 Hệ thống phục vụ trong phạm vi

Hệ thống quản lý thư viện được xây dựng để phục vụ trong phạm vi:

- Thư viện trường học hoặc thư viện quy mô nhỏ.
- Đối tượng sử dụng gồm: Thủ thư và Độc giả.
- Hệ thống hoạt động theo mô hình ứng dụng khách (desktop) kết nối API backend.

#### 2.2 Chức năng hệ thống quản lý thư viện

Hệ thống bao gồm các nhóm chức năng chính sau:

1. Quản lý sách (Book Management)

- Thêm sách mới
- Cập nhật thông tin sách
- Xóa sách
- Quản lý số lượng sách tồn kho
- Phân loại và sắp xếp sách

2. Quản lý độc giả (User/Member Management)

- Thêm thông tin độc giả
- Cập nhật thông tin độc giả
- Tra cứu độc giả
- Quản lý danh sách thành viên

3. Quản lý mượn - trả sách (Borrow/Return Management)

- Lập phiếu mượn sách
- Xử lý trả sách
- Kiểm tra hạn trả
- Theo dõi trạng thái mượn sách

4. Tìm kiếm và tra cứu sách (Search System)

- Tìm kiếm theo tên sách
- Tìm kiếm theo tác giả
- Tìm kiếm theo thể loại
- Xem thông tin chi tiết sách

5. Thống kê và báo cáo (Reporting & Analytics)

- Thống kê số lượng sách đang mượn
- Báo cáo sách quá hạn
- Thống kê tình trạng tồn kho
- Tổng hợp báo cáo hoạt động thư viện

6. Quản lý tài khoản và phân quyền (Security & Authorization)

- Đăng nhập hệ thống
- Xác thực người dùng
- Phân quyền Thủ thư và Độc giả
- Quản lý tài khoản người dùng

#### 2.3 Tổng quan hệ thống

Hệ thống quản lý thư viện được xây dựng nhằm hỗ trợ tự động hóa các nghiệp vụ quản lý sách, quản lý độc giả, xử lý mượn trả sách và thống kê báo cáo. Hệ thống phục vụ các đối tượng sử dụng gồm độc giả, thủ thư và quản trị viên.

Phạm vi hệ thống bao gồm các chức năng diễn ra bên trong thư viện như quản lý dữ liệu, tra cứu, mượn/trả và báo cáo; không bao gồm các hệ thống ngoài phạm vi như thanh toán điện tử hay cổng tích hợp bên thứ ba.

**Bảng 2.1 Tổng quan hệ thống**

| Nội dung          | Mô tả                            |
| ----------------- | -------------------------------- |
| Tên hệ thống      | Hệ thống quản lý thư viện        |
| Mục tiêu          | Tin học hóa quản lý thư viện     |
| Đối tượng sử dụng | Độc giả, Thủ thư, Quản trị viên  |
| Phạm vi           | Quản lý nghiệp vụ trong thư viện |

#### 2.4 Danh sách tác nhân (Actors)

Các tác nhân tương tác với hệ thống được xác định như sau:

**Bảng 2.2 Danh sách tác nhân**

| Actor         | Mô tả                               |
| ------------- | ----------------------------------- |
| Độc giả       | Tìm kiếm, mượn, trả sách            |
| Thủ thư       | Quản lý sách, xử lý mượn/trả        |
| Quản trị viên | Quản trị hệ thống, thống kê báo cáo |

#### 2.5 Danh sách Use Case

Các chức năng chính của hệ thống được mô tả trong bảng sau:

**Bảng 2.3 Danh sách Use Case**

| ID   | Tên Use Case  | Actor            | Mô tả               |
| ---- | ------------- | ---------------- | ------------------- |
| UC01 | Đăng nhập     | Độc giả, Thủ thư | Truy cập hệ thống   |
| UC02 | Tìm kiếm sách | Độc giả          | Tra cứu tài liệu    |
| UC03 | Mượn sách     | Độc giả          | Tạo yêu cầu mượn    |
| UC04 | Trả sách      | Độc giả          | Trả tài liệu        |
| UC05 | Quản lý sách  | Thủ thư          | Thêm, sửa, xóa sách |

#### 2.6 Đặc tả Use Case

**Use Case UC03: Mượn sách**

- Actor: Độc giả
- Mô tả: Use case này cho phép độc giả thực hiện yêu cầu mượn sách từ hệ thống.

Tiền điều kiện:

- Người dùng đã đăng nhập
- Sách còn số lượng khả dụng

Hậu điều kiện:

- Phiếu mượn được tạo thành công

**Bảng 2.4 Luồng chính**

| Actor                  | System                     |
| ---------------------- | -------------------------- |
| 1. Chọn sách muốn mượn | 2. Hiển thị thông tin sách |
| 3. Gửi yêu cầu mượn    | 4. Kiểm tra tồn kho        |
| 5. Xác nhận mượn       | 6. Tạo phiếu mượn          |

Luồng phụ:

- 4a. Nếu sách hết, hệ thống thông báo không thể mượn.

Luồng ngoại lệ:

- E1. Lỗi kết nối cơ sở dữ liệu.

#### 2.7 Quan hệ giữa các Use Case

Các quan hệ giữa các use case được sử dụng để xây dựng sơ đồ Use Case như sau:

**Bảng 2.5 Quan hệ Use Case**

| Use Case  | Quan hệ     | Use Case liên quan  |
| --------- | ----------- | ------------------- |
| Mượn sách | <<include>> | Kiểm tra tồn kho    |
| Đăng nhập | <<include>> | Xác thực người dùng |
| Mượn sách | <<extend>>  | Gia hạn mượn        |

#### 2.8 Sơ đồ Use Case tổng thể

(Sau mục này chèn hình sơ đồ use case bạn vẽ.)

Hình 2.5 Sơ đồ Use Case hệ thống quản lý thư viện.

---

## CHƯƠNG III. THIẾT KẾ HỆ THỐNG

### 3.1 Kiến trúc 3 lớp

Hệ thống áp dụng mô hình 3 lớp:

**Presentation Layer**

Bao gồm giao diện người dùng:

- Đăng nhập
- Quản lý sách
- Mượn trả sách

Công nghệ sử dụng:

- WPF (XAML) cho desktop client

**Business Logic Layer**

Xử lý nghiệp vụ:

- Kiểm tra tồn kho
- Xử lý mượn trả
- Thống kê báo cáo

**Data Access Layer**

Xử lý truy cập dữ liệu:

- Thao tác CRUD
- Truy vấn cơ sở dữ liệu

Công nghệ:

- Entity Framework Core
- SQL Server

### 3.2 Thiết kế cơ sở dữ liệu

Thiết kế cơ sở dữ liệu được cài đặt ở backend trong các entity và `LibraryDbContext`.

**Bảng Books**

| Trường   | Kiểu dữ liệu |
| -------- | ------------ |
| BookId   | int          |
| Title    | nvarchar     |
| Author   | nvarchar     |
| Category | nvarchar     |
| Quantity | int          |

**Bảng Members**

| Trường   | Kiểu dữ liệu |
| -------- | ------------ |
| MemberId | int          |
| FullName | nvarchar     |
| Email    | nvarchar     |

**Bảng BorrowRecords**

| Trường     | Kiểu dữ liệu        |
| ---------- | ------------------- |
| BorrowId   | int                 |
| BookId     | int                 |
| MemberId   | int                 |
| BorrowDate | datetime            |
| DueDate    | datetime            |
| ReturnDate | datetime (nullable) |
| Status     | int                 |

Quan hệ dữ liệu:

- Members 1-n BorrowRecords
- Books 1-n BorrowRecords

(Chèn sơ đồ ERD tại đây)

### 3.3 Entity Framework Core

Hệ thống sử dụng Code First.

Entity Book:

```csharp
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
```

DbContext:

```csharp
public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
}
```

Migration:

```powershell
dotnet ef migrations add InitialCreate --project api --startup-project api
dotnet ef database update --project api --startup-project api
```

---

## CHƯƠNG IV. CÀI ĐẶT VÀ KIỂM THỬ

### 4.1 Công nghệ sử dụng

- C#
- ASP.NET Core Web API
- WPF (XAML)
- Entity Framework Core
- SQL Server

### 4.2 Giao diện chương trình

- (Chèn ảnh giao diện đăng nhập)
- (Chèn ảnh giao diện quản lý sách)
- (Chèn ảnh giao diện mượn trả)

### 4.3 Trạng thái backend hiện tại

- Đã cấu hình kết nối SQL Server qua `DefaultConnection` trong `api/appsettings.json`.
- Đã cài đặt model và quan hệ CSDL ở backend:
  - `api/Models/Book.cs`
  - `api/Models/Member.cs`
  - `api/Models/BorrowRecord.cs`
  - `api/Data/LibraryDbContext.cs`
- Đã khai báo `AddDbContext` trong `api/Program.cs`.

---

## CHƯƠNG V. KẾT LUẬN

Hệ thống quản lý thư viện đã đáp ứng các chức năng cơ bản:

- Quản lý sách
- Quản lý độc giả
- Mượn trả sách
- Thống kê dữ liệu

Trong tương lai có thể mở rộng:

- Quét mã vạch sách
- Gửi email nhắc hạn trả
- Phân quyền nâng cao
