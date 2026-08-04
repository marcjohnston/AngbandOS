namespace AngbandOS.GamePacks.Cthangband;

public class DraconianRacialPowerConfusionOrSoundProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerConfusionBallProjectileScript), 1),
        (nameof(DraconianRacialPowerSoundBallProjectileScript), 2),
    };
}