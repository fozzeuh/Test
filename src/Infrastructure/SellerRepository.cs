using System.Collections.Generic;
using System.Linq;
using Application.Repository;
using Domain;

namespace Infrastructure
{
	internal class SellerRepository : ISellerRepository
	{
		private List<Seller> _sellerList;
		public SellerRepository()
		{
			_sellerList = new List<Seller>();
		}

		public Product AddProductOnSeller(Seller seller, Product product)
		{
			_sellerList.FirstOrDefault(
				s => s.Email.Equals(seller.Email, System.StringComparison.InvariantCultureIgnoreCase)
			).ProductList.Add(product);
			return product;
		}

		public Seller AddSeller(Seller seller)
		{
			_sellerList.Add(seller);
			return seller;
		}

		public Seller GetSellerByEmail(string email)
		{
			return _sellerList.FirstOrDefault(
				s => s.Email.Equals(email, System.StringComparison.InvariantCultureIgnoreCase)
			);
		}

		public List<Product> ListProductBySeller(Seller seller)
		{
			return _sellerList.FirstOrDefault(
				s => s.Email.Equals(seller.Email, System.StringComparison.InvariantCultureIgnoreCase)
			).ProductList;
		}

		public List<Seller> ListSeller()
		{
			return _sellerList;
		}
	}
}