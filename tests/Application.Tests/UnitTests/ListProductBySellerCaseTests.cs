using System;
using Application.Case;
using Application.Exception;
using Application.Repository;
using Domain;
using Moq;
using Xunit;

namespace Application.UnitTests
{
	public class ListProductBySellerCaseTests : IDisposable
	{
		private readonly Mock<ISellerRepository> mockSellerRepository;
		private ListProductBySellerCase listProductCase;
		public ListProductBySellerCaseTests()
		{
			mockSellerRepository = new Mock<ISellerRepository>();
			listProductCase = new ListProductBySellerCase(mockSellerRepository.Object);
		}

		[Fact]
		public void ListProductBySeller_NoExistingSeller_Ok()
		{
			// Arrange
			mockSellerRepository
				.Setup(m => m.GetSellerByEmail(It.IsAny<string>()))
				.Returns((Seller)null);
			Seller seller = new Seller("nameTest", "emailTest");
			// Act
			Assert.Throws<SellerDoesntExistException>(() => listProductCase.ListProductBySeller(seller.Email));

			// Assert
			mockSellerRepository
				.Verify(m => m.GetSellerByEmail(seller.Email), Times.Once);
			mockSellerRepository
				.Verify(m => m.ListProductBySeller(It.IsAny<Seller>()), Times.Never);
		}

		[Fact]
		public void ListProductBySeller_ExistingSeller_Ok()
		{
			// Arrange
			Seller seller = new Seller("nameTest", "emailTest");
			mockSellerRepository
				.Setup(m => m.GetSellerByEmail(It.IsAny<string>()))
				.Returns(seller);
			mockSellerRepository
				.Setup(m => m.ListProductBySeller(It.IsAny<Seller>()))
				.Returns(new System.Collections.Generic.List<Product>());

			// Act
			var result = listProductCase.ListProductBySeller(seller.Email);

			// Assert
			Assert.Empty(result);
			mockSellerRepository
				.Verify(m => m.GetSellerByEmail(It.IsAny<string>()), Times.Once);
			mockSellerRepository
				.Verify(m => m.ListProductBySeller(It.IsAny<Seller>()), Times.Once);
		}

		public void Dispose()
		{
			mockSellerRepository.Reset();
			listProductCase = null;
		}
	}
}