namespace DataLayer.Models
{
    public class BestMatchResults
    {
        public long Ranking { get; set; }
        public string movie_id { get; set; }  // Change to match the database column name
        public string movie_title { get; set; }  // Change to match the database column name
    }
}
