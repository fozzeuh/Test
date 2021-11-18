using System.Collections.Generic;
using Application.Case.Interface;
using Application.Repository;
using Domain;

namespace Application.Case
{
	public class ListBrandCase : IListBrand
	{
		private readonly IBrandRepository brandRepository;

		public ListBrandCase(IBrandRepository brandRepository)
		{
			this.brandRepository = brandRepository;
		}

		public List<Brand> ListBrand()
		{
			return brandRepository.ListBrand();
		}
	}
}