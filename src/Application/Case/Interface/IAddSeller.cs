using Domain;

namespace Application.Case.Interface
{
	public interface IAddSeller
	{
		Seller AddSeller(string name, string email);
	}
}