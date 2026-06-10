namespace AngbandOS.Core;

public sealed class SystemRandomGenerator : IRandomGenerator
{
    private Random random;
    public SystemRandomGenerator()
    {
        random = new Random();
    }
    public SystemRandomGenerator(int seed)
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
