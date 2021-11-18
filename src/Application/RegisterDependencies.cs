using Application.Case;
using Application.Case.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class RegisterDependencies
	{
		public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
		{
			services.AddSingleton<IAddSeller, AddSellerCase>();
			services.AddSingleton<IListSeller, ListSellerCase>();
			services.AddSingleton<IListProductBySeller, ListProductBySellerCase>();
			services.AddSingleton<IAddBrand, AddBrandCase>();
			services.AddSingleton<IAddProductOnSellerStore, AddProductOnSellerStoreCase>();
			services.AddSingleton<IListBrand, ListBrandCase>();
			return services;
		}
	}
}