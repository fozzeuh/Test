using System.Collections.Generic;
using Application.Case.Interface;
using Application.Exception;
using Application.Repository;
using Domain;

namespace Application.Case
{
	public class ListProductBySellerCase : IListProductBySeller
	{
		private readonly ISellerRepository sellerRepository;

		public ListProductBySellerCase(ISellerRepository sellerRepository)
		{
			this.sellerRepository = sellerRepository;
		}

		public List<Product> ListProductBySeller(string email)
		{
			var seller = sellerRepository.GetSellerByEmail(email);
			if (seller == null)
			{
				throw new SellerDoesntExistException($"The user doesn't exist : {email}");
			}
			return sellerRepository.ListProductBySeller(seller);
		}
	}
}