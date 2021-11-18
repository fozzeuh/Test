using Application.Case.Interface;
using Application.Repository;
using Domain;

namespace Application.Case
{
	public class AddBrandCase : IAddBrand
	{
		private readonly IBrandRepository brandRepository;

		public AddBrandCase(IBrandRepository brandRepository)
		{
			this.brandRepository = brandRepository;
		}

		public Brand AddBrand(Brand brand)
		{
			var existingBrand = brandRepository.GetBrand(brand.Name);
			if (existingBrand != null)
			{
				return existingBrand;
			}

			return brandRepository.AddBrand(brand);
		}
	}
}