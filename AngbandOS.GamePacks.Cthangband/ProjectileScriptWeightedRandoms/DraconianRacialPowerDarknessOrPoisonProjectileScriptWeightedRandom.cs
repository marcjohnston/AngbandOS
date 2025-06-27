namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerDarknessOrPoisonProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerDarknessBallProjectileScript), 1),
        (nameof(DraconianRacialPowerPoisonBallProjectileScript), 2),
    };
}