using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iterator_Pattern;

namespace Iterator_Pattern
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestIteratorOnBookCollection()
        {
            // Arrange: Create a book collection and add some books.
            var bookCollection = new BookCollection();
            bookCollection.AddBook(new Book("Book 1", "Author 1"));
            bookCollection.AddBook(new Book("Book 2", "Author 2"));
            bookCollection.AddBook(new Book("Book 3", "Author 3"));

            // Act: Get the iterator and iterate over the collection.
            var iterator = bookCollection.CreateIterator();
            var bookTitles = new System.Collections.Generic.List<string>();

            // Iterate through the books using the iterator.
            while (iterator.HasNext())
            {
                var book = iterator.Next();
                bookTitles.Add(book.Title); // Collecting book titles
            }

            // Assert: Ensure the correct order and content of the book titles.
            Assert.AreEqual(3, bookTitles.Count, "There should be 3 books in the collection.");
            CollectionAssert.AreEqual(new System.Collections.Generic.List<string> { "Book 1", "Book 2", "Book 3" }, bookTitles, "The books are not in the expected order.");
        }

        [TestMethod]
        public void TestIteratorWhenCollectionIsEmpty()
        {
            // Arrange: Create an empty book collection.
            var bookCollection = new BookCollection();

            // Act: Get the iterator for the empty collection.
            var iterator = bookCollection.CreateIterator();
            var bookTitles = new System.Collections.Generic.List<string>();

            // Try iterating through the empty collection.
            while (iterator.HasNext())
            {
                bookTitles.Add(iterator.Next().Title);
            }

            // Assert: Ensure there are no books in the iterator.
            Assert.AreEqual(0, bookTitles.Count, "The collection should be empty.");
        }

        [TestMethod]
        public void TestIteratorForSingleBook()
        {
            // Arrange: Create a book collection with a single book.
            var bookCollection = new BookCollection();
            bookCollection.AddBook(new Book("Book 1", "Author 1"));

            // Act: Get the iterator and iterate over the single-book collection.
            var iterator = bookCollection.CreateIterator();
            var bookTitles = new System.Collections.Generic.List<string>();

            // Iterate through the collection.
            while (iterator.HasNext())
            {
                bookTitles.Add(iterator.Next().Title);
            }

            // Assert: Ensure the collection contains exactly one book.
            Assert.AreEqual(1, bookTitles.Count, "There should be exactly 1 book in the collection.");
            CollectionAssert.AreEqual(new System.Collections.Generic.List<string> { "Book 1" }, bookTitles, "The book is not correctly iterated.");
        }

        [TestMethod]
        public void TestIteratorHasNextAfterCollectionIsFullyIterated()
        {
            // Arrange: Create a book collection and add some books.
            var bookCollection = new BookCollection();
            bookCollection.AddBook(new Book("Book 1", "Author 1"));
            bookCollection.AddBook(new Book("Book 2", "Author 2"));

            // Act: Get the iterator and iterate over the collection.
            var iterator = bookCollection.CreateIterator();
            var bookTitles = new System.Collections.Generic.List<string>();

            while (iterator.HasNext())
            {
                bookTitles.Add(iterator.Next().Title);
            }

            // Assert: Ensure HasNext() returns false after the collection is fully iterated.
            Assert.IsFalse(iterator.HasNext(), "HasNext should return false after iterating through the collection.");
        }

        [TestMethod]
        public void TestIteratorResetAndReiterate()
        {
            // Arrange: Create a book collection and add some books.
            var bookCollection = new BookCollection();
            bookCollection.AddBook(new Book("Book 1", "Author 1"));
            bookCollection.AddBook(new Book("Book 2", "Author 2"));

            // Act: Get the iterator and iterate over the collection.
            var iterator = bookCollection.CreateIterator();
            var firstIterationTitles = new System.Collections.Generic.List<string>();

            // First iteration
            while (iterator.HasNext())
            {
                firstIterationTitles.Add(iterator.Next().Title);
            }

            // Reset the iterator (or recreate it, depending on the design).
            iterator = bookCollection.CreateIterator();
            var secondIterationTitles = new System.Collections.Generic.List<string>();

            // Second iteration after reset
            while (iterator.HasNext())
            {
                secondIterationTitles.Add(iterator.Next().Title);
            }

            // Assert: Ensure both iterations result in the same titles.
            CollectionAssert.AreEqual(firstIterationTitles, secondIterationTitles, "The titles from both iterations should be the same.");
        }
    }
}
