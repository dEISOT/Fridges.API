namespace FridgesModel.Request
{
    public class AssortmentPutRequest
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
