namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerMissileOrExpolodeProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(DraconianRacialPowerMissileBallProjectileScript), 1),
        (nameof(DraconianRacialPowerExplodeBallProjectileScript), 2),
    };
}