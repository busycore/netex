namespace dotnetex.shared.Providers.CalculadoraProvider
{
    public class SomaCalculadora : ICalculadoraProvider
    {
        public double operacao(double a, double b)
        {
            return a + b;
        }
    }
}