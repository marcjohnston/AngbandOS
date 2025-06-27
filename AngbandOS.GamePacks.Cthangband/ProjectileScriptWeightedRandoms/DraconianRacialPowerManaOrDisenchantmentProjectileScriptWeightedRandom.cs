namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerManaOrDisenchantmentProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerManaBallProjectileScript), 1),
        (nameof(DraconianRacialPowerDisenchantmentBallProjectileScript), 2),
    };
}