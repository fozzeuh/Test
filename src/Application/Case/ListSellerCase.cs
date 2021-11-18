using System.Collections.Generic;
using Application.Case.Interface;
using Application.Repository;
using Domain;

namespace Application.Case
{
	internal class ListSellerCase : IListSeller
	{
		private readonly ISellerRepository sellerRepository;

		public ListSellerCase(ISellerRepository sellerRepository)
		{
			this.sellerRepository = sellerRepository;
		}

		public List<Seller> ListSeller()
		{
			return sellerRepository.ListSeller();
		}
	}
}