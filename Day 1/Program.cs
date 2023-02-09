using Lab1;

// 1. Ask the user for a publisher name & sorting method (sorting criteria (by Title, price, etc….) and
// sorting way (ASC. Or DESC.))…. And implement a function named FindBooksSorted() that displays all books written
// by this Author sorted as the user requested.
// Try this: FunBooks
Console.Write("Enter Publisher name: ");
string publisherName = Console.ReadLine();

Console.Write("Enter Sorting Criteria (title / price / subject): ");
string sortingCriteria = Console.ReadLine();

Console.Write("Enter Sorting method (Asc / Desc): ");
string sortingMethod = Console.ReadLine();

GetBooksSorted(publisherName, sortingCriteria, sortingMethod);

List<Book> GetBooksSorted(string publisher, string sortBy, string sortMethod)
{
    var booksQuery = SampleData.Books
        .Where(b => b.Publisher.Name == publisher);

    if (sortingMethod == "asc")
    {
        switch (sortBy)
        {
            case "title":
                booksQuery.OrderBy(b => b.Title);
                break;
            case "price":
                booksQuery.OrderBy(b => b.Price);
                break;
            case "subject":
                booksQuery.OrderBy(b => b.Subject.Name);
                break;
        }
    }
    else if (sortingMethod == "desc")
    {
        switch (sortBy)
        {
            case "title":
                booksQuery.OrderByDescending(b => b.Title);
                break;
            case "price":
                booksQuery.OrderByDescending(b => b.Price);
                break;
            case "subject":
                booksQuery.OrderByDescending(b => b.Subject.Name);
                break;
        }
    }

    return booksQuery.ToList();
}

// 1. Display book title and its ISBN.
var problem1 = SampleData.Books.Select(b => new { b.Title, b.Isbn }).ToList();

foreach (var item in problem1)
{
    Console.WriteLine($"{item.Title} - ISBN: {item.Isbn}");
}

// 2. Display the first 3 books with price more than 25.
var problem2 = SampleData.Books.Where(b => b.Price > 25).Take(3).ToList();

foreach (var item in problem2)
{
    Console.WriteLine($"{item.Title} - Price: {item.Price}");
}

// 3. Display Book title along with its publisher name. (Using 2 methods).
var problem3 = SampleData.Books.Select(b => new { b.Title, b.Publisher.Name }).ToList();

var problem3Expression = from b in SampleData.Books
                         select new { b.Title, b.Publisher.Name };

foreach (var item in problem3)
{
    Console.WriteLine($"{item.Title} - Publisher: {item.Name}");
}

// 4. Find the number of books which cost more than 20.
var problem4 = SampleData.Books.Count(b => b.Price > 20);
Console.WriteLine($"Count of books whose price is more than 20 is {problem4}");

// 5. Display book title, price and subject name sorted by its subject name ascending and by its price descending.
var problem5 = SampleData.Books
    .Select(b => new { b.Title, b.Price, b.Subject })
    .OrderBy(b => b.Subject)
    .ThenByDescending(b => b.Price).ToList();

foreach (var item in problem5)
{
    Console.WriteLine($"{item.Title} - Price: {item.Price} - Subject: {item.Subject}");
}

// 6. Display All subjects with books related to this subject. (Using 2 methods).
var problem6 = SampleData.Books.Select(b => b.Subject).ToList();

var problem6Expression = from b in SampleData.Books
                         select new
                         {
                             name = b.Title,
                             subs = from s in SampleData.Subjects
                                    where s.Name == b.Subject.Name
                                    select s.Name
                         };

foreach (var item in problem6Expression)
{
    foreach (var subject in item.subs)
    {
        Console.WriteLine($"{item.name} - {subject}");
    }
}

// 7. Try to display book title & price (from book objects) returned from GetBooks Function.
var problem7 = SampleData.GetBooks().OfType<Book>();

foreach (var item in problem7)
{
    string title = item.Title;
    decimal price = item.Price;

    Console.WriteLine($"{title} - Price: {price}");
}

// 8. Display books grouped by publisher & Subject.
var problem8 = SampleData.Books.GroupBy(b => new { b.Publisher, b.Subject }).ToList();

foreach (var item in problem8)
{
    Console.WriteLine($"{item.Key.Subject} - {item.Key.Publisher.Name}");
}