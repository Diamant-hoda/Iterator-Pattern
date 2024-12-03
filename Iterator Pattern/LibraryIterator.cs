// Concrete Iterator
using System.Collections.Generic;

public class LibraryIterator : IIterator<Book>
{
    private readonly List<Book> _books;
    private int _position = 0;

    public LibraryIterator(List<Book> books)
    {
        _books = books;
    }

    public bool HasNext()
    {
        return _position < _books.Count;
    }

    public Book Next()
    {
        return HasNext() ? _books[_position++] : null;
    }
}
