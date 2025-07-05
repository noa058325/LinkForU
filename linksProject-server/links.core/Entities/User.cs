namespace links.Entities
{
    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNamber { get; set; }

        // אחד לרבים
        public List<Recommend> Recommends { get; set; } // רשימה של המלצות של המשתמש
    }
}
