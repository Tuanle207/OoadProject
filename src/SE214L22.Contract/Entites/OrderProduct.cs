namespace SE214L22.Contract.Entities
{
    public class OrderProduct : AppEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Number { get; set; }


        public Product Product { get; set; }
    }
}
