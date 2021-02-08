using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace EMERIOSChallenge.Tests
{
    public class ServiceMatrixTests
    {
        [Fact]
        public void ServiceMatrix_ExtractColumns()
        {
            //arrange
            string matrix = Fakes.GetDefaultMatrix();
            List<string> rows = Fakes.GetDefaultListOfRows();
            int expectedCols = 7;

            //act
            ServiceMatrix service = new ServiceMatrix();
            List<string> result = service.ExtractColumns(rows, matrix);

            //asserts
            result.Should().NotBeNull();
            result.Should().HaveCount(expectedCols);
        }

        [Fact]
        public void ServiceMatrix_ExtractDiagonal_NormalWay()
        {
            //arrange
            string matrix = Fakes.GetDefaultMatrix();
            List<string> rows = Fakes.GetDefaultListOfRows();
            int expectedDiagonals = 9;

            //act
            ServiceMatrix service = new ServiceMatrix();
            List<string> result = service.ExtractDiagonal(rows, false, matrix);

            //asserts
            result.Should().NotBeNull();
            result.Should().HaveCount(expectedDiagonals);
        }

        [Fact]
        public void ServiceMatrix_ExtractDiagonal_Reverse()
        {
            //arrange
            string matrix = Fakes.GetDefaultMatrix();
            List<string> rows = Fakes.GetDefaultListOfRows();
            int expectedDiagonals = 9;

            //act
            ServiceMatrix service = new ServiceMatrix();
            List<string> result = service.ExtractDiagonal(rows, true, matrix);

            //asserts
            result.Should().NotBeNull();
            result.Should().HaveCount(expectedDiagonals);
        }

        [Fact]
        public void ServiceMatrix_ExtractRows()
        {
            //arrange
            string matrix = Fakes.GetDefaultMatrix();
            int expectedRows = 7;
            
            //act
            ServiceMatrix service = new ServiceMatrix();
            List<string> result = service.ExtractRows(matrix);

            //asserts
            result.Should().NotBeNull();
            result.Should().HaveCount(expectedRows);
        }
    }
}
