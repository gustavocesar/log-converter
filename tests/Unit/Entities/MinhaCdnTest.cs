using LogConverter.Domain.Entities;

namespace LogConverterTest.Unit.Entities;

public class MinhaCdnTest
{
    [Fact]
    public void Should_be_possible_convert_MinhaCdn_to_Agora()
    {
        //Arrange
        var minhaCdn = new Mock<MinhaCdn>();

        //Act
        var agora = (Agora)minhaCdn.Object;

        //Assert
        Assert.IsType<Agora>(agora);
    }

    [Fact]
    public void Should_be_possible_convert_String_to_MinhaCdn()
    {
        //Arrange
        var line = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2";

        //Act
        var minhaCdn = (MinhaCdn)line;

        //Assert
        Assert.IsType<MinhaCdn>(minhaCdn);
    }
}