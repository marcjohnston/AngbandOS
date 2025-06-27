namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacialPowerHellFireOrHolyFireProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(DraconianRacialPowerHellFireBallProjectileScript), 1),
        (nameof(DraconianRacialPowerHolyFireBallProjectileScript), 2),
    };
}