
namespace JobFinder.Entities.Entities
{
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public string FileId { get; set; }
        public string Path { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
