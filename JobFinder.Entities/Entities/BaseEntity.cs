namespace JobFinder.Entities.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
