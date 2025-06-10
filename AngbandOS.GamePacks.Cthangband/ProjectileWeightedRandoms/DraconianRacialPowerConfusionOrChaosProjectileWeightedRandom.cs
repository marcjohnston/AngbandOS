namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerConfusionOrChaosProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerConfusionBallProjectileScript), 1),
        (nameof(DraconianRacialPowerChaosBallProjectileScript), 2),
    };
}