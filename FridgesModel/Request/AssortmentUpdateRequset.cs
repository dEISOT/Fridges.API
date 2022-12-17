namespace FridgesModel.Request
{
    public class AssortmentUpdateRequset
    {
        public Guid AssortmentId { get; set; }
        public int NewQuantity { get; set; }

    }
}
