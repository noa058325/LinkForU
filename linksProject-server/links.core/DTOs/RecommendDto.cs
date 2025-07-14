using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace links.core.DTOs
{
    // DTO להצגת תגובה למשתמשים
    public class RecommendDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LikesCount { get; set; }
    }

    // DTO ליצירת תגובה חדשה
    public class RecommendCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    // DTO לעדכון תגובה קיימת
    public class RecommendUpdateDto
    {
        public string Description { get; set; } 
    }
}
