﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ChaosDisenchantSoundOrShards250rm2ProjectileWeightedRandom : ProjectileWeightedRandomScript
{
    private ChaosDisenchantSoundOrShards250rm2ProjectileWeightedRandom(Game game) : base(game) { }

    protected override (string, int)[] NameAndWeightBindingTuples => new (string, int)[]
    {
        (nameof(Chaos250rm2ProjectileScript), 1),
        (nameof(Disenchant250rm2ProjectileScript), 1),
        (nameof(Sound250rm2ProjectileScript), 1),
        (nameof(Explode250rm2ProjectileScript), 1),
    };
}
