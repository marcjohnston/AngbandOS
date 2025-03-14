﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AcidBoltOrBeam6d8ProjectileWeightedRandom : ProjectileWeightedRandomScript
{
    private AcidBoltOrBeam6d8ProjectileWeightedRandom(Game game) : base(game) { }

    protected override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(Acid6d8ProjectileScript), 20),
        (nameof(AcidBeam6d8ProjectileScript), 80),
    };
}
