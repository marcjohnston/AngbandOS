// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ElectricityArtifactBias : ArtifactBias
{
    private ElectricityArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandartItemCharacteristics.ResElec)
        {
            item.RandartItemCharacteristics.ResElec = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (item.Factory.CanApplyArtifactBiasResistance && !item.RandartItemCharacteristics.ShElec)
        {
            item.RandartItemCharacteristics.ShElec = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (SaveGame.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImElec)
        {
            item.RandartItemCharacteristics.ImElec = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
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
            if (!item.RandartItemCharacteristics.BrandElec)
            {
                item.RandartItemCharacteristics.BrandElec = true;
                if (SaveGame.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (SaveGame.Rng.DieRoll(3) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BoElec1Activation));
        }
        else if (SaveGame.Rng.DieRoll(5) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BaElec2Activation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BaElec3Activation));
        }
    }
}
