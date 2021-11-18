using System.Text.Json.Serialization;

namespace Api.Models
{
	public class ProductRequest
	{
		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("stock")]
		public int Stock { get; set; }

		[JsonPropertyName("price")]
		public decimal Price { get; set; }
	}
}