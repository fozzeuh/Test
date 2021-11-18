using System;
using Application.Case;
using Application.Exception;
using Application.Repository;
using Domain;
using Moq;
using Xunit;

namespace Application.UnitTests
{
	public class AddProductOnSellerStoreCaseTests : IDisposable
	{
		private readonly Mock<ISellerRepository> mockSellerRepository;
		private AddProductOnSellerStoreCase addProductCase;
		public AddProductOnSellerStoreCaseTests()
		{
			mockSellerRepository = new Mock<ISellerRepository>();
			addProductCase = new AddProductOnSellerStoreCase(mockSellerRepository.Object);
		}

		[Fact]
		public void AddProductOnSellerStore_NoExistingSeller_Ok()
		{
			// Arrange
			mockSellerRepository
				.Setup(m => m.GetSellerByEmail(It.IsAny<string>()))
				.Returns((Seller)null);
			Seller seller = new Seller("nameTest", "emailTest");
			Product product = new Product
			{
				Price = 25,
				Stock = 25,
				Title = "productTitle"
			};
			// Act
			Assert.Throws<SellerDoesntExistException>(() => addProductCase.AddProductOnSellerStore(product, seller.Email));

			// Assert
			mockSellerRepository
				.Verify(m => m.GetSellerByEmail(seller.Email), Times.Once);
			mockSellerRepository
				.Verify(m => m.AddProductOnSeller(It.IsAny<Seller>(), It.IsAny<Product>()), Times.Never);
		}

		[Fact]
		public void AddProductOnSellerStore_ExistingSeller_Ok()
		{
			// Arrange
			Seller seller = new Seller("nameTest", "emailTest");
			Product product = new Product
			{
				Price = 25,
				Stock = 25,
				Title = "productTitle"
			};
			mockSellerRepository
				.Setup(m => m.GetSellerByEmail(It.IsAny<string>()))
				.Returns(seller);
			mockSellerRepository
				.Setup(m => m.AddProductOnSeller(It.IsAny<Seller>(), It.IsAny<Product>()))
				.Returns(product);

			// Act
			var result = addProductCase.AddProductOnSellerStore(product, seller.Email);

			// Assert
			Assert.Equal(result.Price, product.Price);
			Assert.Equal(result.Stock, product.Stock);
			Assert.Equal(result.Title, product.Title);
			mockSellerRepository
				.Verify(m => m.GetSellerByEmail(seller.Email), Times.Once);
			mockSellerRepository
				.Verify(m => m.AddProductOnSeller(It.IsAny<Seller>(), It.IsAny<Product>()), Times.Once);
		}

		public void Dispose()
		{
			mockSellerRepository.Reset();
			addProductCase = null;
		}
	}
}