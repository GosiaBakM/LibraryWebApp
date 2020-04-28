using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryWebApp.Models
{
    public class JsonFileConnector : IJsonFileConnector
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileConnector(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public JsonFileConnector()
        {
        }

        public string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "BookCatalog.json"); }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Book[]>(jsonFileReader.ReadToEnd());
            }
        }

        public bool SaveBooks(IEnumerable<Book> books)
        {
            string dataToJSON = JsonSerializer.Serialize(books);
            File.WriteAllText(JsonFileName, dataToJSON);
            return true;
        }

    }
}
