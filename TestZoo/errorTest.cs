namespace TestZoo;

public class errorTest
{
    [Fact]
    public void ShowRequestId_ReturnsTrue_WhenRequestIdIsNotEmpty()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel
        {
            RequestId = "123"
        };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ShowRequestId_ReturnsFalse_WhenRequestIdIsEmpty()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel
        {
            RequestId = string.Empty
        };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ShowRequestId_ReturnsFalse_WhenRequestIdIsNull()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel
        {
            RequestId = null
        };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        Assert.False(result);
    }
    
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}