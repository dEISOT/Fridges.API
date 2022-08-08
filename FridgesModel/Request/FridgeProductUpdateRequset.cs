namespace FridgesModel.Request
{
    public class FridgeProductUpdateRequset
    {
        public Guid FridgeProductId { get; set; }
        public int NewQuantity { get; set; }

    }
}
