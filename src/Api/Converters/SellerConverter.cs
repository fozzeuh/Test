using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Domain;

namespace Api.Converters
{
	public static class SellerConverter
	{
		public static SellerResponse ConverToSellerResponse(this Seller seller)
		{
			return new SellerResponse(seller.Name, seller.Email);
		}

		public static SellerListResponse ConverToSellerResponseList(this List<Seller> sellerList)
		{
			return new SellerListResponse
			{
				SellerResponseList = sellerList.Select(s => s.ConverToSellerResponse()).ToList()
			};
		}
	}
}