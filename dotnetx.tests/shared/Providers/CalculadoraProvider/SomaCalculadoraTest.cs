using dotnetex.shared.Providers.CalculadoraProvider;
using Xunit;

namespace dotnetex.tests.shared.Providers.CalculadoraProvider
{
    public class SomaCalculadoraTest
    {

        [Fact(DisplayName = "Should be able to Calculate the sum")]
        public void SomaCalculadoraUnitTest()
        {
            // Arranje
            double a = 1;
            double b = 2;

            // Act
            SomaCalculadora calc = new SomaCalculadora();
            var c = calc.operacao(a, b);

            // Assert
            Assert.Equal(3, c);
        }

        [Fact(DisplayName = "Should be not be able to Calculate the sum")]
        public void SomaCalculadoraUnitTest2()
        {
            // Arranje
            double a = 1;
            double b = 2;

            // Act
            SomaCalculadora calc = new SomaCalculadora();
            var c = calc.operacao(a, b);

            // Assert
            Assert.Equal(3, c);
        }
    }
}