// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ColdArtifactBias : ArtifactBias
{
    private ColdArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandartItemCharacteristics.ResCold)
        {
            item.RandartItemCharacteristics.ResCold = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (SaveGame.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImCold)
        {
            item.RandartItemCharacteristics.ImCold = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyArtifactBiasSlaying)
        {
            if (!item.RandartItemCharacteristics.BrandCold)
            {
                item.RandartItemCharacteristics.BrandCold = true;
                if (SaveGame.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (SaveGame.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BoCold1Activation));
        }
        else if (SaveGame.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BaCold1Activation));
        }
        else if (SaveGame.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BaCold2Activation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BaCold3Activation));
        }
    }
}
