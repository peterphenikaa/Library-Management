using LibraryManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(LibraryDbContext db)
    {
        if (await db.Books.AnyAsync() || await db.Members.AnyAsync() || await db.BorrowRecords.AnyAsync())
        {
            return;
        }

        var books = new[]
        {
            new Book { Title = "Lập trình C# cơ bản", Author = "Nguyễn Văn A", Category = "Lập trình", Quantity = 5 },
            new Book { Title = "ASP.NET Core Web API", Author = "Trần Văn B", Category = "Web", Quantity = 4 },
            new Book { Title = "Cơ sở dữ liệu SQL Server", Author = "Lê Thị C", Category = "Database", Quantity = 6 }
        };

        var members = new[]
        {
            new Member { FullName = "Nguyễn Minh Anh", Email = "minhanh@example.com" },
            new Member { FullName = "Trần Thu Hà", Email = "thuha@example.com" }
        };

        db.Books.AddRange(books);
        db.Members.AddRange(members);
        await db.SaveChangesAsync();

        db.BorrowRecords.AddRange(
        [
            new BorrowRecord
            {
                BookId = books[0].BookId,
                MemberId = members[0].MemberId,
                BorrowDate = DateTime.UtcNow.AddDays(-3),
                DueDate = DateTime.UtcNow.AddDays(7),
                Status = BorrowStatus.Borrowing
            },
            new BorrowRecord
            {
                BookId = books[1].BookId,
                MemberId = members[1].MemberId,
                BorrowDate = DateTime.UtcNow.AddDays(-10),
                DueDate = DateTime.UtcNow.AddDays(-2),
                ReturnDate = DateTime.UtcNow.AddDays(-1),
                Status = BorrowStatus.Returned
            }
        ]);

        await db.SaveChangesAsync();
    }
}
