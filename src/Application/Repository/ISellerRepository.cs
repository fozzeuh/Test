using System.Collections.Generic;
using Domain;

namespace Application.Repository
{
	public interface ISellerRepository
	{
		Seller AddSeller(Seller seller);
		List<Seller> ListSeller();
		Seller GetSellerByEmail(string email);
		Product AddProductOnSeller(Seller seller, Product product);
		List<Product> ListProductBySeller(Seller seller);
	}
}