using System;
using Application.Case;
using Application.Exception;
using Application.Repository;
using Domain;
using Moq;
using Xunit;

namespace Application.UnitTests
{
	public class AddSellerCaseTests : IDisposable
	{
		private readonly Mock<ISellerRepository> mockSellerRepository;
		private AddSellerCase addSellerCase;
		public AddSellerCaseTests()
		{
			mockSellerRepository = new Mock<ISellerRepository>();
			addSellerCase = new AddSellerCase(mockSellerRepository.Object);
		}

		[Fact]
		public void AddSeller_NewSeller_Ok()
		{
			// Arrange
			mockSellerRepository
				.Setup(m => m.GetSellerByEmail(It.IsAny<string>()))
				.Returns((Seller)null);
			Seller seller = new Seller("nameTest", "emailTest");
			mockSellerRepository
				.Setup(m => m.AddSeller(It.IsAny<Seller>()))
				.Returns(seller);
			// Act
			var result = addSellerCase.AddSeller(seller.Name, seller.Email);

			// Assert
			Assert.Equal(result.Name, seller.Name);
			Assert.Equal(result.Email, seller.Email);
			mockSellerRepository
				.Verify(m => m.GetSellerByEmail(seller.Email), Times.Once);
			mockSellerRepository
				.Verify(m => m.AddSeller(It.IsAny<Seller>()), Times.Once);
		}

		[Fact]
		public void AddSeller_ExistingSeller_Ok()
		{
			// Arrange
			Seller seller = new Seller("nameTest", "emailTest");
			mockSellerRepository
				.Setup(m => m.GetSellerByEmail(It.IsAny<string>()))
				.Returns(seller);

			// Act
			Assert.Throws<SellerAlreadyExistException>(() => addSellerCase.AddSeller(seller.Name, seller.Email));

			// Assert
			mockSellerRepository
				.Verify(m => m.GetSellerByEmail(seller.Email), Times.Once);
			mockSellerRepository
				.Verify(m => m.AddSeller(It.IsAny<Seller>()), Times.Never);
		}

		public void Dispose()
		{
			mockSellerRepository.Reset();
			addSellerCase = null;
		}
	}
}