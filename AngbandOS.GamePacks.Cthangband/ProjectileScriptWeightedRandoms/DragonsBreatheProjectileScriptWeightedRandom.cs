﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonsBreatheProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(Acid100Rn3ProjectileScript), 1),
        (nameof(Electricity80Rn3ProjectileScript), 1),
        (nameof(Fire100Rn3ProjectileScript), 1),
        (nameof(Cold80Rn3ProjectileScript), 1),
        (nameof(PoisonGas60rm3ProjectileScript), 1),
    };
}
