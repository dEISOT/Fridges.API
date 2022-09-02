namespace FridgesModel.Request
{
    public class AssortmentUpdateRequset
    {
        public Guid FridgeProductId { get; set; }
        public int NewQuantity { get; set; }

    }
}
