namespace JobFinder.Entities.Entities
{
    public class Application : BaseEntity
    {
        public bool IsSubmitted { get; set; }
        public string CoverLetter { get; set; }

        public int JobSeekerId { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }


    }
}
