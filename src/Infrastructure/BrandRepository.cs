using System.Collections.Generic;
using System.Linq;
using Application.Repository;
using Domain;

namespace Infrastructure
{
	public class BrandRepository : IBrandRepository
	{
		private List<Brand> brands = new List<Brand>();
		public BrandRepository()
		{
		}

		public Brand AddBrand(Brand brand)
		{
			brands.Add(brand);
			return brand;
		}

		public Brand GetBrand(string name)
		{
			return brands.FirstOrDefault(b => b.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
		}

		public List<Brand> ListBrand()
		{
			return brands;
		}
	}
}