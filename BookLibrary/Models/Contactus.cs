using MessagePack;

namespace BookLibrary.Models
{
    public class Contactus
    {
        [Key(0)]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }   
        public string Message { get; set; }

    }
}
