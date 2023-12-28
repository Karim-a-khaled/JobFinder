namespace JobFinder.Entities.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] CvFile { get; set; }

        public int JobSeekerId { get; set; } 
        public JobSeeker JobSeeker { get; set; }
    }
}
