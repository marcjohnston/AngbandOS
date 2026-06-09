namespace AngbandOS.Core;

public sealed class SystemRng : IRandomGenerator
{
    private Random random;
    public SystemRng()
    {
        random = new Random();
    }
    public SystemRng(int seed)
    {
        random = new Random(seed);
    }

    public int Next(int maxValue)
    {
        return random.Next(maxValue);
    }
    public double NextDouble()
    {
        return random.NextDouble();
    }
}
