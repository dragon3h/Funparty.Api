namespace Funparty.Api.Domain.Entities
{
    public class MascotPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string Name { get; set; }
        public Mascot Mascot { get; set; }
        public int MascotId { get; set; }
    }
}
