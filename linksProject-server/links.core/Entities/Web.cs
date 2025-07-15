namespace links.Entities
{
    public class Web
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }

        // יחיד לרבים
        public int idCategory { get; set; }
        public Category Category { get; set; } // קשר לקטגוריה

        public string? ImageUrl { get; set; }
        public string? Coupon { get; set; }
    }
}
