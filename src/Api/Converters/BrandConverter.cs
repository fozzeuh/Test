using Api.Models;
using Domain;

namespace Api.Converters
{
	public static class BrandConverter
	{
		public static Brand ConvertToBrand(this BrandRequest request)
		{
			return new Brand
			{
				Name = request.Name
			};
		}
	}
}