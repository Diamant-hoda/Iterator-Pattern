// Main Program
using System;

public class Program
{
    public static void Main()
    {
        // Create a book collection
        var collection = new BookCollection();
        collection.AddBook(new Book("1984", "George Orwell"));
        collection.AddBook(new Book("Brave New World", "Aldous Huxley"));

        // Create an iterator for the collection
        var iterator = collection.CreateIterator();

        // Iterate through the collection
        Console.WriteLine("Books in the library:");
        while (iterator.HasNext())
        {
            var book = iterator.Next();
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }
}
