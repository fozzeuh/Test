using System.Text.Json.Serialization;

namespace Api.Models
{
	public class BrandRequest
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}