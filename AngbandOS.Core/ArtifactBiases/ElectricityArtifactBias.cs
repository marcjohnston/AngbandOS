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
        if (!item.RandomArtifactItemCharacteristics.ResElec)
        {
            item.RandomArtifactItemCharacteristics.ResElec = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (item.Factory.CanApplyArtifactBiasResistance && !item.RandomArtifactItemCharacteristics.ShElec)
        {
            item.RandomArtifactItemCharacteristics.ShElec = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (SaveGame.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandomArtifactItemCharacteristics.ImElec)
        {
            item.RandomArtifactItemCharacteristics.ImElec = true;
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
            if (!item.RandomArtifactItemCharacteristics.BrandElec)
            {
                item.RandomArtifactItemCharacteristics.BrandElec = true;
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
            return SaveGame.SingletonRepository.Activations.Get(nameof(LightningBolt4d8Every6p1d6Activation));
        }
        else if (SaveGame.DieRoll(5) != 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BallOfLightning100r3Every500Activation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(LargeLightningBall250Every425p1d425Activation));
        }
    }
}
