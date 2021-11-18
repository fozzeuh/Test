using Application.Case.Interface;
using Application.Exception;
using Application.Repository;
using Domain;

namespace Application.Case
{
	public class AddSellerCase : IAddSeller
	{
		private readonly ISellerRepository sellerRepository;

		public AddSellerCase(ISellerRepository sellerRepository)
		{
			this.sellerRepository = sellerRepository;
		}

		public Seller AddSeller(string name, string email)
		{
			var seller = new Seller(name, email);
			if (sellerRepository.GetSellerByEmail(email) != null)
			{
				throw new SellerAlreadyExistException($"Seller with this email : {email} already exist");
			}
			var addedSeller = sellerRepository.AddSeller(seller);
			return addedSeller;
		}
	}
}