using Application.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class RegisterDependencies
	{
		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddSingleton<ISellerRepository, SellerRepository>();
			services.AddSingleton<IBrandRepository, BrandRepository>();
			return services;
		}
	}
}