namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerConfusionOrChaosProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerConfusionBallProjectileScript), 1),
        (nameof(DraconianRacialPowerChaosBallProjectileScript), 2),
    };
}