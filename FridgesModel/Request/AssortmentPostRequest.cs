namespace FridgesModel.Request
{
    public class AssortmentPostRequest
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
