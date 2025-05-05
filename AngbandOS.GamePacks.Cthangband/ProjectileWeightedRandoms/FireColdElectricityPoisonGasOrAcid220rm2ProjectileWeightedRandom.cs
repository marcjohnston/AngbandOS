// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireColdElectricityPoisonGasOrAcid220rm2ProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(Fire250rm2ProjectileScript), 1),
        (nameof(Cold250rm2ProjectileScript), 1),
        (nameof(Acid250rm2ProjectileScript), 1),
        (nameof(Electricity250rm2ProjectileScript), 1),
        (nameof(PoisonGas250rm2ProjectileScript), 1),
    };
}
