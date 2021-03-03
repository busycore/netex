namespace dotnetex.shared.Providers.CalculadoraProvider
{
    public class SubtracaoCalculadora : ICalculadoraProvider
    {
        public double operacao(double a, double b)
        {
            return a + b;
        }
    }
}