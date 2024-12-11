

using Business.Helpers;

namespace Presentation.Console.MainApp.Tests.Helpers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]
    public void UniqueIdentifierGenerator_GenerateUniqueId_ShouldReturnStringOfTypeGuid()
    {
        //arrange

        //act
        string id = UniqueIdentifierGenerator.GenerateUniqueId();

        //Assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }
}
