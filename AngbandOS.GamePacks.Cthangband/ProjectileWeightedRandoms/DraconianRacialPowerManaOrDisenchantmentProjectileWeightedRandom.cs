namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerManaOrDisenchantmentProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(DraconianRacialPowerManaBallProjectileScript), 1),
        (nameof(DraconianRacialPowerDisenchantmentBallProjectileScript), 2),
    };
}