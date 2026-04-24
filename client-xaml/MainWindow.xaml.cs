using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace LibraryManagement.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static readonly HttpClient HttpClient = new();
    private readonly List<BookRow> _books;
    private readonly ObservableCollection<BookRow> _filteredBooks;

    public MainWindow()
    {
        InitializeComponent();

        _books =
        [
            new BookRow("B001", "Lập trình C# căn bản", "Nguyễn Văn A", "Kỹ thuật", 7),
            new BookRow("B002", "Clean Architecture", "Robert C. Martin", "Kiến trúc", 3),
            new BookRow("B003", "Design Patterns", "Gang of Four", "Kiến trúc", 2),
            new BookRow("B004", "ASP.NET Core in Action", "Andrew Lock", "Web API", 5),
            new BookRow("B005", "Database Design", "Trần Thị B", "Cơ sở dữ liệu", 4)
        ];

        _filteredBooks = new ObservableCollection<BookRow>(_books);
        BooksDataGrid.ItemsSource = _filteredBooks;
    }

    private async void CheckApiButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var baseUrl = ApiBaseUrlTextBox.Text.Trim().TrimEnd('/');
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                StatusTextBlock.Text = "Vui lòng nhập API Base URL.";
                return;
            }

            var response = await HttpClient.GetAsync($"{baseUrl}/weatherforecast");
            if (!response.IsSuccessStatusCode)
            {
                StatusTextBlock.Text = $"API phản hồi lỗi: {(int)response.StatusCode} {response.StatusCode}";
                return;
            }

            var payload = await response.Content.ReadAsStringAsync();
            var weather = JsonSerializer.Deserialize<List<WeatherItem>>(payload, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            StatusTextBlock.Text = weather is { Count: > 0 }
                ? $"Kết nối API thành công. Nhận {weather.Count} bản ghi weatherforecast."
                : "Kết nối API thành công nhưng chưa có dữ liệu.";
        }
        catch (Exception ex)
        {
            StatusTextBlock.Text = $"Không kết nối được API: {ex.Message}";
        }
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        var keyword = KeywordTextBox.Text.Trim();
        var results = string.IsNullOrWhiteSpace(keyword)
            ? _books
            : _books.Where(book =>
                book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                book.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                book.Code.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        _filteredBooks.Clear();
        foreach (var book in results)
        {
            _filteredBooks.Add(book);
        }

        StatusTextBlock.Text = $"Tìm thấy {_filteredBooks.Count} kết quả.";
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var email = EmailTextBox.Text.Trim();
        var hasPassword = PasswordBox.Password.Length > 0;

        if (string.IsNullOrWhiteSpace(email) || !hasPassword)
        {
            StatusTextBlock.Text = "Vui lòng nhập email và mật khẩu để đăng nhập.";
            return;
        }

        StatusTextBlock.Text = $"Đăng nhập demo thành công cho tài khoản: {email}";
    }

    private sealed record BookRow(string Code, string Title, string Author, string Category, int Available);
    private sealed record WeatherItem(DateTime Date, int TemperatureC, string? Summary);
}