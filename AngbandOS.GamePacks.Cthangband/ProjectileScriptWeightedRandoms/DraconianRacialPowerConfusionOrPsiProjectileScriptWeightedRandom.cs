namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerConfusionOrPsiProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerConfusionBallProjectileScript), 1),
        (nameof(DraconianRacialPowerPsiBallProjectileScript), 2),
    };
}