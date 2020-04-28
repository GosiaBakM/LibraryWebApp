using AutoMapper;
using LibraryWebApp.Models;

namespace LibraryWebApp.Data
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<Book, BookModel>().ReverseMap();        
        }
    }
}
