namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerHellFireOrHolyFireProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(DraconianRacialPowerHellFireBallProjectileScript), 1),
        (nameof(DraconianRacialPowerHolyFireBallProjectileScript), 2),
    };
}