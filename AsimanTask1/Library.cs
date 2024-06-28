namespace _27_06.Task2;

public class Library : Base
{
    private static int _id;
    public Book[] _books;

    public Library(string name) : base(name)
    {
        _books = new Book[0];
        Id = ++_id;
    }

    public void AddBook(Book book)
    {
        Array.Resize(ref _books, _books.Length + 1);
        _books[^1] = book;
    }
    public void ListAllBooks()
    {
        foreach (Book book in _books)
        {
            Console.WriteLine(book);
        }
    }
}
