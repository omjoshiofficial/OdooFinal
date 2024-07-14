using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace LibraryManagement.UserSide
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Book>> FetchBooksByQuery(string query)
        {
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={query}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                return ParseBooks(jsonData);
            }
            return new List<Book>();
        }
        public async Task<List<Book>> FetchAllBooks()
        {
            // Use a general query to get a wide range of books
            string apiUrl = "https://www.googleapis.com/books/v1/volumes?q=books&maxResults=40"; // Adjust maxResults as needed

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                return ParseBooks(jsonData);
            }
            return new List<Book>();
        }

        public async Task<Book> GetBookById(string bookId)
        {
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes/{bookId}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                var volumeInfo = JObject.Parse(jsonData)["volumeInfo"];
                return new Book
                {
                    Title = volumeInfo["title"]?.ToString(),
                    Author = volumeInfo["authors"]?[0]?.ToString(),
                    Publisher = volumeInfo["publisher"]?.ToString(),
                    PublishedDate = volumeInfo["publishedDate"]?.ToString(),
                    Description = volumeInfo["description"]?.ToString(),
                    Thumbnail = volumeInfo["imageLinks"]?["thumbnail"]?.ToString()
                };
            }

            return null; // Return null if no book found
        }

        public async Task<JObject> GetBookByISBN(string isbn)
        {
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes/{isbn}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                var jsonResult = JObject.Parse(jsonData);
                var items = jsonResult["items"];

                // If items exist, return the first one (unique book)
                if (items != null && items.HasValues)
                {
                    return (JObject)items[0]; // Return the first book
                }
            }

            return null; // Return null if no book found
        }

        private List<Book> ParseBooks(string jsonData)
        {
            JObject json = JObject.Parse(jsonData);
            var items = json["items"];
            var books = new List<Book>();

            if (items != null)
            {
                foreach (var item in items)
                {
                    var id = item["id"];
                    var volumeInfo = item["volumeInfo"];
                    var book = new Book
                    {
                        Title = volumeInfo["title"]?.ToString(),
                        Author = volumeInfo["authors"]?[0]?.ToString(),
                        Publisher = volumeInfo["publisher"]?.ToString(),
                        PublishedDate = volumeInfo["publishedDate"]?.ToString(),
                        Description = volumeInfo["description"]?.ToString(),
                        PageCount = volumeInfo["pageCount"]?.ToObject<int>() ?? 0,
                        Thumbnail = volumeInfo["imageLinks"]?["thumbnail"]?.ToString(),
                        Id = id.ToString()
                    };
                    books.Add(book);
                }
            }

            return books;
        }
    }
}