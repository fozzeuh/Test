using Api.Converters;
using Api.Models;
using Application.Case.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/v1/brands")]
	public class BrandController : Controller
	{
		private readonly IAddBrand addBrand;
		private readonly IListBrand listBrand;

		public BrandController(
			IAddBrand addBrand,
			IListBrand listBrand)
		{
			this.addBrand = addBrand;
			this.listBrand = listBrand;
		}

		[HttpPost]
		public IActionResult CreateBrand([FromBody] BrandRequest request)
		{
			addBrand.AddBrand(request.ConvertToBrand());
			return Ok(request);
		}

		[HttpGet]
		public IActionResult ListBrand()
		{
			return Ok(listBrand.ListBrand());
		}
	}
}