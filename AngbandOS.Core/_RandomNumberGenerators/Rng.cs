namespace AngbandOS.Core;

public sealed class Rng
{
    private ulong _s0;
    private ulong _s1;
    private ulong _s2;
    private ulong _s3;

    public Rng(ulong seed)
    {
        // Use SplitMix64 to expand a single seed into 256 bits of state.
        ulong state = seed;

        _s0 = SplitMix64(ref state);
        _s1 = SplitMix64(ref state);
        _s2 = SplitMix64(ref state);
        _s3 = SplitMix64(ref state);
    }

    public Rng(
        ulong s0,
        ulong s1,
        ulong s2,
        ulong s3)
    {
        _s0 = s0;
        _s1 = s1;
        _s2 = s2;
        _s3 = s3;

        if ((_s0 | _s1 | _s2 | _s3) == 0)
            throw new ArgumentException("State cannot be all zeros.");
    }

    public (ulong S0, ulong S1, ulong S2, ulong S3) GetState()
        => (_s0, _s1, _s2, _s3);

    public void SetState(
        ulong s0,
        ulong s1,
        ulong s2,
        ulong s3)
    {
        if ((s0 | s1 | s2 | s3) == 0)
            throw new ArgumentException("State cannot be all zeros.");

        _s0 = s0;
        _s1 = s1;
        _s2 = s2;
        _s3 = s3;
    }

    public ulong NextUInt64()
    {
        ulong result = RotateLeft(_s0 + _s3, 23) + _s0;

        ulong t = _s1 << 17;

        _s2 ^= _s0;
        _s3 ^= _s1;
        _s1 ^= _s2;
        _s0 ^= _s3;

        _s2 ^= t;

        _s3 = RotateLeft(_s3, 45);

        return result;
    }

    public uint NextUInt32()
    {
        return (uint)(NextUInt64() >> 32);
    }

    public int Next()
    {
        return (int)(NextUInt64() & 0x7FFFFFFF);
    }

    public int Next(int maxValue)
    {
        if (maxValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        return (int)(NextUInt64() % (ulong)maxValue);
    }

    public int Next(int minValue, int maxValue)
    {
        if (minValue >= maxValue)
            throw new ArgumentOutOfRangeException();

        ulong range = (ulong)(maxValue - minValue);

        return minValue + (int)(NextUInt64() % range);
    }

    public double NextDouble()
    {
        return (NextUInt64() >> 11) * (1.0 / (1UL << 53));
    }

    private static ulong RotateLeft(ulong x, int k)
    {
        return (x << k) | (x >> (64 - k));
    }

    private static ulong SplitMix64(ref ulong state)
    {
        ulong z = (state += 0x9E3779B97F4A7C15UL);
        z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
        z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
        return z ^ (z >> 31);
    }
}