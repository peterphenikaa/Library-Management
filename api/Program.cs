using LibraryManagement.Api.Data;
using LibraryManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    await db.Database.MigrateAsync();
    await DbSeeder.SeedAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Ok(new
{
    Message = "Library Management API is running",
    Time = DateTime.UtcNow
}));

app.MapGet("/api/database/check", async (LibraryDbContext db) =>
{
    var canConnect = await db.Database.CanConnectAsync();
    return canConnect
        ? Results.Ok(new { Connected = true, Database = db.Database.GetDbConnection().Database })
        : Results.Problem("Can not connect to database.");
});

app.MapGet("/api/books", async (LibraryDbContext db) =>
    await db.Books
        .AsNoTracking()
        .OrderBy(x => x.Title)
        .ToListAsync());

app.MapPost("/api/books", async (Book book, LibraryDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/api/books/{book.BookId}", book);
});

app.MapGet("/api/members", async (LibraryDbContext db) =>
    await db.Members
        .AsNoTracking()
        .OrderBy(x => x.FullName)
        .ToListAsync());

app.MapPost("/api/members", async (Member member, LibraryDbContext db) =>
{
    db.Members.Add(member);
    await db.SaveChangesAsync();
    return Results.Created($"/api/members/{member.MemberId}", member);
});

app.MapGet("/api/borrow-records", async (LibraryDbContext db) =>
    await db.BorrowRecords
        .AsNoTracking()
        .Include(x => x.Book)
        .Include(x => x.Member)
        .OrderByDescending(x => x.BorrowDate)
        .ToListAsync());

app.MapPost("/api/borrow-records", async (BorrowRecord borrowRecord, LibraryDbContext db) =>
{
    db.BorrowRecords.Add(borrowRecord);
    await db.SaveChangesAsync();
    return Results.Created($"/api/borrow-records/{borrowRecord.BorrowId}", borrowRecord);
});

app.Run();
