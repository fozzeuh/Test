using System.Collections.Generic;
using Domain;

namespace Application.Case.Interface
{
	public interface IListProductBySeller
	{
		List<Product> ListProductBySeller(string email);
	}
}