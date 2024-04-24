using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.Data;
using BookLibrary.Models;
using System.Threading.Tasks;
using BookShop.Controllers;

public class ContactControllerTests
{
    private readonly ContactController _controller;
    private readonly Mock<BookLibraryDb> _mockContext;

    public ContactControllerTests()
    {
        _mockContext = new Mock<BookLibraryDb>();
        _controller = new ContactController(_mockContext.Object);
    }

    [Fact]
    public void Contactus_ReturnsView()
    {
        // Act
        var result = _controller.Contactus() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Contact", result.ViewName);
    }

    [Fact]
    public void ContactusPOST_ValidModel_AddsToDatabaseAndReturnsView()
    {
        // Arrange
        var contactModel = new Contactus { FirstName = "John", LastName = "Doe", email = "john.doe@example.com", phone = "1234567890", Message = "Hello!" };
        _mockContext.Setup(db => db.Add(It.IsAny<Contactus>())).Verifiable();
        _mockContext.Setup(db => db.SaveChanges()).Verifiable();

        // Act
        var result = _controller.contactusPOST(contactModel) as ViewResult;

        // Assert
        _mockContext.Verify(db => db.Add(It.IsAny<Contactus>()), Times.Once()); 
        _mockContext.Verify(db => db.SaveChanges(), Times.Once()); 
        Assert.NotNull(result);
        Assert.Equal("contact", result.ViewName);
        Assert.IsType<Contactus>(result.Model);
        Assert.Equal("Successfully submitted!", _controller.ViewBag.status); 
    }

    [Fact]
    public void ContactusPOST_InvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var contactModel = new Contactus { FirstName = "", LastName = "Doe", email = "john.doe@example.com", phone = "1234567890", Message = "Hello!" };
        _controller.ModelState.AddModelError("Name", "Name is required");

        // Act
        var result = _controller.contactusPOST(contactModel) as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("contact", result.ViewName);
        Assert.False(_controller.ModelState.IsValid);
        Assert.Equal(contactModel, result.Model);
    }


}
