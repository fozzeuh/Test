using System.Collections.Generic;

namespace Domain
{
	public class Seller
	{
		public Seller(string name, string email)
		{
			this.Name = name;
			this.Email = email;
		}
		public string Name { get; set; }
		public string Email { get; set; }
		public List<Product> ProductList { get; set; } = new List<Product>();
	}
}