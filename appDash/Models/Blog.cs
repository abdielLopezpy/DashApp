namespace appDash.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime PublicationDate { get; set; }

        public required string AuthorEmail { get; set; }
    }
}
