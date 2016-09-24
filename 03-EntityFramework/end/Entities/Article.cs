namespace Articles.Entities
{
    public class Article : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}