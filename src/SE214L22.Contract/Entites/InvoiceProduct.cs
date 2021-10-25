namespace SE214L22.Contract.Entities
{
    public class InvoiceProduct : AppEntity
    {
        public int ProductId { get; set; }
        public int Number { get; set; }
        public int InvoiceId { get; set; }

        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}
