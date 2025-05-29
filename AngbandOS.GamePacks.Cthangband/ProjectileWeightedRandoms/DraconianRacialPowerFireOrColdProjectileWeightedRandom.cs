namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerFireOrColdProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(DraconianRacialPowerColdBallProjectileScript), 1),
        (nameof(DraconianRacialPowerFireBallProjectileScript), 2),
    };
}