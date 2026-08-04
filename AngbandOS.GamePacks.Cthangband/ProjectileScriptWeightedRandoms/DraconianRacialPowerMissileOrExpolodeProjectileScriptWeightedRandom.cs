namespace AngbandOS.GamePacks.Cthangband;

public class DraconianRacialPowerMissileOrExpolodeProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerMissileBallProjectileScript), 1),
        (nameof(DraconianRacialPowerExplodeBallProjectileScript), 2),
    };
}