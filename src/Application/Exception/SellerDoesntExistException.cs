namespace Application.Exception
{
	public class SellerDoesntExistException : System.Exception
	{
		public SellerDoesntExistException(string message) : base(message)
		{
		}
	}
}