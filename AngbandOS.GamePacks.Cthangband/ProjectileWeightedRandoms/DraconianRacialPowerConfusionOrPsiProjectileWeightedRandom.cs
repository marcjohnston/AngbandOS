namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerConfusionOrPsiProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerConfusionBallProjectileScript), 1),
        (nameof(DraconianRacialPowerPsiBallProjectileScript), 2),
    };
}