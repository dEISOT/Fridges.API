namespace FridgesCore.Domain
{
    public class Assortment
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
