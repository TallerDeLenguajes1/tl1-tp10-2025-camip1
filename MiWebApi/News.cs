using System.Dynamic;

namespace EspacioNoticias
{
    public class News
    {
        public Pagination pagination { get; set; }
        public List<NewsItem> data { get; set; }
    }

    public class Pagination {
        int limit { get; set; }
        int offset { get; set; }
        int count { get; set; }
        int total { get; set; }
    }
    public class NewsItem {
        public string author{ get; set; }
        public string title{ get; set; }
        public string description{ get; set; }
        public string url{ get; set; }
        public string source { get; set; }
        public string image{ get; set; }
        public string category{ get; set; }
        public string language{ get; set; }
        public string country{ get; set; }
        public string published_at{ get; set; }
    }
}