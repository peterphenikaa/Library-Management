namespace LibraryManagement.Api.Models;

public class BorrowRecord
{
    public int BorrowId { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public BorrowStatus Status { get; set; } = BorrowStatus.Borrowing;

    public Book? Book { get; set; }
    public Member? Member { get; set; }
}

public enum BorrowStatus
{
    Borrowing = 1,
    Returned = 2,
    Overdue = 3
}
