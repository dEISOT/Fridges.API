namespace FridgesData.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public virtual ICollection<FridgeProductEntity> FridgeProductEntities { get; set; }
    }
}
