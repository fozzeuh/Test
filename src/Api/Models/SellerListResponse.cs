using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models
{
	public class SellerListResponse
	{
		[JsonPropertyName("sellers")]
		public List<SellerResponse> SellerResponseList { get; set; }
	}
}