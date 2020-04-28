namespace LibraryWebApp.Models
{
    public class Author
    {
        //public int AutorId { get; private set; }
        public int AutorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return $"{FullName}";
        }

    }
}
