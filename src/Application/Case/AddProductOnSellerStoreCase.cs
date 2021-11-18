using Application.Case.Interface;
using Application.Exception;
using Application.Repository;
using Domain;

namespace Application.Case
{
	public class AddProductOnSellerStoreCase : IAddProductOnSellerStore
	{
		private readonly ISellerRepository sellerRepository;

		public AddProductOnSellerStoreCase(ISellerRepository sellerRepository)
		{
			this.sellerRepository = sellerRepository;
		}

		public Product AddProductOnSellerStore(Product product, string email)
		{
			var seller = sellerRepository.GetSellerByEmail(email);
			if (seller == null)
			{
				throw new SellerDoesntExistException($"The user doesn't exist : {email}");
			}

			return sellerRepository.AddProductOnSeller(seller, product);
		}
	}
}