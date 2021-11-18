namespace Application.Exception
{
	public class SellerAlreadyExistException : System.Exception
	{
		public SellerAlreadyExistException(string message) : base(message)
		{
		}
	}
}