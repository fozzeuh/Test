using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Domain;

namespace Api.Converters
{
	public static class ProductConverter
	{
		public static Product ConvertToProduct(this ProductRequest request)
		{
			return new Product
			{
				Price = request.Price,
				Stock = request.Stock,
				Title = request.Title
			};
		}

		public static ProductResponse ConvertToProductResponse(this Product product)
		{
			return new ProductResponse
			{
				Price = product.Price,
				Stock = product.Stock,
				Title = product.Title
			};
		}

		public static ProductListResponse ConvertToProductListResponse(this List<Product> products)
		{
			return new ProductListResponse
			{
				Products = products.Select(p => p.ConvertToProductResponse()).ToList()
			};
		}
	}
}