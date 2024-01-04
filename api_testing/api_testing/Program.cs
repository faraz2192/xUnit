using api_testing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string jsonFilePath = "D:\\bio.json";

        // check if file exists
        if (File.Exists(jsonFilePath))
        {
            // Read Json file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the file
            List<MyData> myDataList = JsonConvert.DeserializeObject<List<MyData>>(jsonContent);
            foreach (MyData data in myDataList)
            {
                Console.WriteLine("Name: " + data.Name);
                Console.WriteLine("Language: " + data.Language);
                Console.WriteLine("ID: " + data.Id);
                Console.WriteLine("Bio: " + data.Bio);
                Console.WriteLine("Version: " + data.Version);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
}




/* using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var books = new List<Book>();

void InitializeBooks() => books = Enumerable.Range(1, 5)
    .Select(index => new Book(index, $"Awesome book #{index}"))
    .ToList();

InitializeBooks();

app.MapGet("/books", () =>
{
    return Results.Ok(books);
});

app.MapPost("/books", (Book book) =>
{
    books.Add(book);
    return Results.Created($"/books/{book.BookId}", book);
});

app.MapPut("/books", (Book book) =>
{
    books.RemoveAll(book => book.BookId == book.BookId);
    books.Add(book);
    return Results.Ok(book);
});

app.MapDelete("/books/{bookId}", (int bookId) =>
{
    books.RemoveAll(book => book.BookId == bookId);
    return Results.NoContent();
});

app.MapDelete("/state", () =>
{
    InitializeBooks();
    return Results.NoContent();
});

app.MapGet("/admin", ([FromHeader(Name = "X-Api-Key")] string apiKey) =>
{
    if (apiKey == "SuperSecretApiKey")
    {
        return Results.Ok("Hi admin!");
    }

    return Results.Unauthorized();
});

app.Run();

internal record Book(int BookId, string Title);

*/