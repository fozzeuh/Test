using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models
{
	public class ProductListResponse
	{
		[JsonPropertyName("products")]
		public List<ProductResponse> Products { get; set; }
	}
}