﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireBoltOrBeam6d8ProjectileScriptGenericWeightedRandom : ProjectileScriptGenericWeightedRandom
{
    private FireBoltOrBeam6d8ProjectileScriptGenericWeightedRandom(Game game) : base(game) { }

    protected override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(Fire6d8ProjectileScript), 1),
        (nameof(FireBeam6d8ProjectileScript), 1),
    };
}