using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BookLibrary.Controllers;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using BookLibrary.ViewModels;

public class CatalogControllerTests
{
    private readonly Mock<BookLibraryDb> _mockContext;
    private readonly Mock<DbSet<Book>> _mockSet;
    private readonly Mock<IWebHostEnvironment> _mockEnvironment;
    private readonly CatalogController _controller;

    public CatalogControllerTests()
    {
        _mockContext = new Mock<BookLibraryDb>();
        _mockSet = new Mock<DbSet<Book>>();
        _mockEnvironment = new Mock<IWebHostEnvironment>();

        _mockContext.Setup(m => m.Books).Returns(_mockSet.Object);

        _controller = new CatalogController(_mockContext.Object, _mockEnvironment.Object);
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
        };
    }

    [Fact]
    public void All_ReturnsViewWithFilteredBooks()
    {
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "C# Fundamentals", Genre = new Genre { Name = "Education" }},
        new Book { Id = 2, Title = "ASP.NET Core Essentials", Genre = new Genre { Name = "Technology" }}
    }.AsQueryable();

        var mockSet = new Mock<DbSet<Book>>();
        mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
        mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
        mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
        mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

        _mockContext.Setup(m => m.Books).Returns(mockSet.Object);

        var result = _controller.All("Education", null) as ViewResult;
        var model = result.Model as IEnumerable<Book>;

        Assert.Single(model); // Check if only one book is returned
        Assert.Equal("C# Fundamentals", model.First().Title); // Verify correct book is returned
    }

    [Fact]
    public void Create_Get_ReturnsEmptyForm()
    {
        var result = _controller.Create() as ViewResult;
        Assert.NotNull(result);
    }

    [Fact]
    public void Create_Post_ValidData_CreatesBookAndRedirects()
    {
        var bookVM = new BookVM { Title = "New Book", Author = "Author", Publisher = "Publisher" };
        _mockSet.Setup(m => m.Add(It.IsAny<Book>())).Verifiable();
        _mockContext.Setup(m => m.SaveChanges()).Verifiable();

        var result = _controller.Create(bookVM, "Education") as RedirectToActionResult;

        Assert.Equal("Details", result.ActionName);
        _mockSet.Verify();
        _mockContext.Verify();
    }


    [Fact]
    public void Edit_Get_InvalidId_ReturnsNotFound()
    {
        var result = _controller.Edit(0) as NotFoundResult;
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_Post_ValidId_DeletesBookAndRedirects()
    {
        var book = new Book { Id = 1, Title = "Delete Me" };
        _mockSet.Setup(m => m.Find(1)).Returns(book);
        _mockContext.Setup(m => m.Books).Returns(_mockSet.Object);
        _mockContext.Setup(m => m.SaveChanges()).Verifiable();

        var result = _controller.Delete(new Book { Id = 1 }) as RedirectToActionResult;

        Assert.Equal("All", result.ActionName);
        _mockSet.Verify(m => m.Remove(It.IsAny<Book>()), Times.Once());
        _mockContext.Verify();
    }

}
