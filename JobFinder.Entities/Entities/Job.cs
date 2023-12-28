namespace JobFinder.Entities.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
