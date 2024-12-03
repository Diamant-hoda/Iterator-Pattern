// Concrete Aggregate
using System.Collections.Generic;

public class BookCollection : IAggregate<Book>
{
    private readonly List<Book> _books = new();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new LibraryIterator(_books);
    }
}
