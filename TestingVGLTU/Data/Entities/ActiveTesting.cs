namespace TestingVGLTU.Data.Entities
{
    public class ActiveTesting
    {
        public int Id { get; set; }
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
        public Testing Testing { get; set; } = null!;
        public int TestingId { get; set; }
        public DateTime DatePublication { get; set; }
        //public IEnumerable<UserResponsesToTests> UserResponsesToTests { get; set; } = null!;

    }
}
