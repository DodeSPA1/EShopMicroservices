using System.Runtime.Serialization;

namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException : Exception
    {

        public ProductNotFoundException() : base("Product not found!")
        {
        }
    }
}
