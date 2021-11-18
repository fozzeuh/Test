using Domain;

namespace Application.Case.Interface
{
	public interface IAddProductOnSellerStore
	{
		Product AddProductOnSellerStore(Product product, string email);
	}
}