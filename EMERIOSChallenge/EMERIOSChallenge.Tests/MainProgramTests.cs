using FluentAssertions;
using Moq;
using Xunit;

namespace EMERIOSChallenge.Tests
{
    public class MainProgramTests
    {
        [Fact]
        public void MainProgram_Constructor()
        {
            Mock<IServiceIO> serviceIO = new Mock<IServiceIO>();
            Mock<IServiceMatrix> serviceMatrix = new Mock<IServiceMatrix>();
            Mock<IStringsHelper> stringsHelper = new Mock<IStringsHelper>();
            Mock<ICustomConfiguration> customConfiguration = new Mock<ICustomConfiguration>();
            MainProgram program = new MainProgram(serviceIO.Object, serviceMatrix.Object, stringsHelper.Object, customConfiguration.Object);
            program.Should().NotBeNull();
        }
    }
}
