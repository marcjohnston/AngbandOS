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
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImCold)
        {
            item.RandartItemCharacteristics.ImCold = true;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Category != ItemTypeEnum.Bow)
        {
            if (!item.RandartItemCharacteristics.BrandCold)
            {
                item.RandartItemCharacteristics.BrandCold = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (Program.Rng.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<BoCold1Activation>();
        }
        else if (Program.Rng.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<BaCold1Activation>();
        }
        else if (Program.Rng.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<BaCold2Activation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<BaCold3Activation>();
        }
    }
}
