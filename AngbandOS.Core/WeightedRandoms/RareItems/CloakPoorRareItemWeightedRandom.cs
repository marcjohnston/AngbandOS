﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WeightedRandoms;

[Serializable]
internal class CloakPoorRareItemWeightedRandom : RareItemWeightedRandom
{
    private CloakPoorRareItemWeightedRandom(Game game) : base(game) { } // This object is a singleton.
    protected override (string, int)[] ItemFactoryNamesAndWeights => new (string, int)[]
    {
        (nameof(CloakOfIrritationRareItem), 1),
        (nameof(CloakOfVulnerabilityRareItem), 1),
        (nameof(CloakOfEnvelopingRareItem), 1)
    };
}
