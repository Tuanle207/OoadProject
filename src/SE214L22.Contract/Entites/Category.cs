namespace SE214L22.Contract.Entities
{
    public class Category : AppEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float ReturnRate { get; set; }
    }
}
