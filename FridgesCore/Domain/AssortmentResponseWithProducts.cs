using FridgesData.Entities;
using FridgesModel.Response;

namespace FridgesCore.Domain
{
    public class AssortmentResponseWithProducts
    {
        public IEnumerable<AssortmentResponse> AssortmentList { get; set; }
        public IEnumerable<ProductEntity> ProductList { get; set; }
    }
}
