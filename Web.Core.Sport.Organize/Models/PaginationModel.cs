using System.Text.Json.Serialization;

namespace Web.Core.Sport.Organize.Models
{
    public class PaginationModel
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("links")]
        public Link Links { get; set; }
    }
    public class Link
    {
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        [JsonPropertyName("next")]
        public string Next { get; set; }
    }
    public class MetaModel
    {
        [JsonPropertyName("pagination")]
        public PaginationModel Pagination { get; set; }
    }
}
