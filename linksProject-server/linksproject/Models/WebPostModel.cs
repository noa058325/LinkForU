namespace linksproject.Models
{
    public class WebSummaryDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class WebPostModel
    {
        public string name { get; set; }
        public string link { get; set; }
        public int idCategory { get; set; }
        public string? ImageUrl { get; set; }
        public string? Coupon { get; set; }
    }
}

