﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class DexterityArtifactBias : ArtifactBias
{
    private DexterityArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandartItemCharacteristics.Dex)
        {
            item.RandartItemCharacteristics.Dex = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.RandartItemCharacteristics.SustDex)
        {
            item.RandartItemCharacteristics.SustDex = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
}