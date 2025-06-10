namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerManaOrDisenchantmentProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerManaBallProjectileScript), 1),
        (nameof(DraconianRacialPowerDisenchantmentBallProjectileScript), 2),
    };
}