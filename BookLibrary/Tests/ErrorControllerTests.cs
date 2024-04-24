using Xunit;
using Microsoft.AspNetCore.Mvc;
using BookShop.Controllers;

public class ErrorControllerTests
{
    private readonly ErrorController _controller;

    public ErrorControllerTests()
    {
        _controller = new ErrorController();
    }

    [Fact]
    public void Error404_ReturnsNotFoundView()
    {
        // Act
        var result = _controller.Error404() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("NotFound", result.ViewName);
    }

    [Fact]
    public void Error500_ReturnsInternalErrorView()
    {
        // Act
        var result = _controller.Error500() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("InternalError", result.ViewName);
    }

    [Theory]
    [InlineData(404, "NotFound")]
    [InlineData(500, "InternalError")]
    [InlineData(403, "GenericError")]
    public void HttpStatusCodeHandler_ReturnsCorrectViewBasedOnStatusCode(int statusCode, string expectedViewName)
    {
        // Act
        var result = _controller.HttpStatusCodeHandler(statusCode) as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedViewName, result.ViewName);
    }


    [Fact]
    public void NotFound_ReturnsNotFoundView()
    {
        // Act
        var result = _controller.NotFound() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("NotFound", result.ViewName); // Assuming this returns a specific NotFound view
    }

    [Fact]
    public void InternalError_ReturnsInternalErrorView()
    {
        // Act
        var result = _controller.InternalError() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("InternalError", result.ViewName); // Assuming this returns a specific InternalError view
    }

}
