using System;
using Application.Case;
using Application.Repository;
using Domain;
using Moq;
using Xunit;

namespace Application.UnitTests
{
	public class AddBrandCaseTests : IDisposable
	{
		private readonly Mock<IBrandRepository> mockBrandRepository;
		private AddBrandCase addBrandCase;
		public AddBrandCaseTests()
		{
			mockBrandRepository = new Mock<IBrandRepository>();
			addBrandCase = new AddBrandCase(mockBrandRepository.Object);
		}

		[Fact]
		public void AddBrand_NewBranch_Ok()
		{
			// Arrange
			mockBrandRepository
				.Setup(m => m.GetBrand(It.IsAny<string>()))
				.Returns((Brand)null);
			Brand brand = new Brand
			{
				Name = "test"
			};
			mockBrandRepository
				.Setup(m => m.AddBrand(It.IsAny<Brand>()))
				.Returns(brand);
			// Act
			var result = addBrandCase.AddBrand(brand);

			// Assert
			Assert.Equal(result.Name, brand.Name);
			mockBrandRepository
				.Verify(m => m.GetBrand(brand.Name), Times.Once);
			mockBrandRepository
				.Verify(m => m.AddBrand(brand), Times.Once);
		}

		[Fact]
		public void AddBrand_ExistingBranch_Ok()
		{
			// Arrange
			Brand brand = new Brand
			{
				Name = "test"
			};
			mockBrandRepository
				.Setup(m => m.GetBrand(It.IsAny<string>()))
				.Returns(brand);
			// Act
			var result = addBrandCase.AddBrand(brand);

			// Assert
			Assert.Equal(result.Name, brand.Name);
			mockBrandRepository
				.Verify(m => m.GetBrand(brand.Name), Times.Once);
			mockBrandRepository
				.Verify(m => m.AddBrand(brand), Times.Never);
		}

		public void Dispose()
		{
			mockBrandRepository.Reset();
			addBrandCase = null;
		}
	}
}