using System.Collections.Generic;
using Domain;

namespace Application.Repository
{
	public interface IBrandRepository
	{
		Brand AddBrand(Brand brand);

		Brand GetBrand(string name);
		List<Brand> ListBrand();
	}
}