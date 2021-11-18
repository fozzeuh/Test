using System.Text.Json.Serialization;

namespace Api.Models
{
	public class SellerResponse
	{
		public SellerResponse(string name, string email)
		{
			Name = name;
			Email = email;
		}

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }
	}
}