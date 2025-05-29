namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkElfRacialPowerProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(DarkElfBeamRacialPowerProjectileScript), 10),
        (nameof(DarkElfBoltRacialPowerProjectileScript), 90),
    };
}