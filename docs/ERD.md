# Sơ đồ Cơ sở Dữ liệu (Database Schema / ERD)

Dưới đây là thiết kế mô hình cơ sở dữ liệu (Entity Relationship Diagram) cho hệ thống Quản lý Thư Cáo dựa trên các Use Case đã phân tích.

```mermaid
erDiagram
    Users ||--o{ Roles : has
    Users {
        int Id PK
        string FullName
        string Email
        string PasswordHash
        string Phone
        string Address
        int RoleId FK
        datetime CreatedAt
        boolean IsActive
    }
    
    Roles {
        int Id PK
        string Name
        string Description
    }

    Categories ||--o{ Books : "classify"
    Categories {
        int Id PK
        string Name
        string Description
    }

    Books {
        int Id PK
        string Title
        string Author
        string Publisher
        int PublishYear
        int CategoryId FK
        string ISBN
        int TotalCopies
        int AvailableCopies
        boolean IsActive
    }

    Users ||--o{ BorrowTickets : "create/own"
    BorrowTickets ||--|{ BorrowDetails : "contain"
    BorrowTickets {
        int Id PK
        int UserId FK
        int CreatedByAdminId FK "Thủ thư tạo phiếu"
        datetime BorrowDate
        datetime DueDate
        datetime ReturnDate "Ngày trả thực tế"
        string Status "Pending / Borrowing / Returned / Overdue"
    }

    BorrowDetails {
        int Id PK
        int TicketId FK
        int BookId FK
        string Status "Normal / Lost / Damaged"
    }
    Books ||--o{ BorrowDetails : "are borrowed in"

    BorrowTickets ||--o{ Fines : "generate"
    Fines {
        int Id PK
        int TicketId FK
        int UserId FK
        decimal Amount
        string Reason "Overdue / Lost / Damaged"
        boolean IsPaid
    }
```

### Các Entity Chính:
1. **Users & Roles:** Quản lý tài khoản (Độc giả, Thủ thư, Admin). Phân biệt quyền thao tác bằng RoleId.
2. **Books & Categories:** Sách và Danh mục sách. Lưu số lượng tồn kho `AvailableCopies` (cập nhật liên tục khi có mượn/trả).
3. **BorrowTickets & BorrowDetails:** Quản lý giao dịch mượn/trả sách. Một Phiếu Mượn có thể có nhiều chi tiết (Mượn nhiều sách cùng lúc).
4. **Fines:** Lịch sử nộp phạt (nếu trả quá hạn hoặc sách bị hư hỏng). Tương ứng trực tiếp với Phiếu Mượn vi phạm.
