// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class WarriorArtifactBias : ArtifactBias 
{
    private WarriorArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.Str)
        {
            item.RandomArtifactItemCharacteristics.Str = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (!item.RandomArtifactItemCharacteristics.Con)
        {
            item.RandomArtifactItemCharacteristics.Con = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (!item.RandomArtifactItemCharacteristics.Dex)
        {
            item.RandomArtifactItemCharacteristics.Dex = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyRandomResistances(Item item)
    {
        if (SaveGame.DieRoll(3) != 1 && !item.RandomArtifactItemCharacteristics.ResFear)
        {
            item.RandomArtifactItemCharacteristics.ResFear = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (SaveGame.DieRoll(3) == 1 && !item.RandomArtifactItemCharacteristics.NoMagic)
        {
            item.RandomArtifactItemCharacteristics.NoMagic = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override int ActivationPowerChance => 80;
    public override Activation GetActivationPowerType(Item item)
    {
        if (SaveGame.DieRoll(100) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(InvulnActivation));

        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(Berserk50p1d50Every100p1d100Activation));
        }
    }
}
