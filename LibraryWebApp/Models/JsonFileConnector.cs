using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class JsonFileConnector : IJsonFileBookService
    {       
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileConnector(IWebHostEnvironment webHostEnvironment)
        {       
            WebHostEnvironment = webHostEnvironment;
        }
        //TODO change to private 
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

        public void SaveBooks(IEnumerable<Book> books)
        {
            string dataToJSON = JsonSerializer.Serialize(books);
            File.WriteAllText(JsonFileName, dataToJSON);
        }

    }
}
