namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerDarknessOrPoisonProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(DraconianRacialPowerDarknessBallProjectileScript), 1),
        (nameof(DraconianRacialPowerPoisonBallProjectileScript), 2),
    };
}