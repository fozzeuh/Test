using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
	public class SellerRequest
	{
		[JsonPropertyName("name")]
		[Required]
		public string Name { get; set; }

		[JsonPropertyName("email")]
		[Required]
		public string Email { get; set; }
	}
}