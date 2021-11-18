using Api.Converters;
using Api.Models;
using Application.Case.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/v1/sellers")]
	public class SellerController : Controller
	{
		private readonly IListSeller listSeller;
		private readonly IAddSeller addSeller;
		private readonly IAddProductOnSellerStore addProductOnSellerStore;
		private readonly IListProductBySeller listProductBySeller;

		public SellerController(
			IListSeller listSeller,
			IAddSeller addSeller,
			IAddProductOnSellerStore addProductOnSellerStore,
			IListProductBySeller listProductBySeller)
		{
			this.addSeller = addSeller;
			this.addProductOnSellerStore = addProductOnSellerStore;
			this.listProductBySeller = listProductBySeller;
			this.listSeller = listSeller;
		}

		[HttpGet]
		public IActionResult List()
		{
			return Ok(listSeller.ListSeller());
		}

		[HttpPost]
		public IActionResult Create([FromBody] SellerRequest request)
		{
			return Ok(addSeller.AddSeller(request.Name, request.Email));
		}

		[HttpPost("{sellerEmail}/products")]
		public IActionResult AddProductOnSellerStore(
			[FromBody] ProductRequest request,
			[FromRoute(Name = "sellerEmail")] string sellerEmail)
		{
			return Ok(addProductOnSellerStore.AddProductOnSellerStore(request.ConvertToProduct(), sellerEmail).ConvertToProductResponse());
		}

		[HttpGet("{sellerEmail}/products")]
		public IActionResult ListProductBySeller([FromRoute(Name = "sellerEmail")] string sellerEmail)
		{
			return Ok(listProductBySeller.ListProductBySeller(sellerEmail).ConvertToProductListResponse());
		}
	}
}