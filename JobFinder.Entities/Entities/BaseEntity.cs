namespace JobFinder.Entities.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
