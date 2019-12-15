namespace Funparty.Api.Domain.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}