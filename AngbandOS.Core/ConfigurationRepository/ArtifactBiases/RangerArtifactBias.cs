// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class RangerArtifactBias : ArtifactBias
{
    private RangerArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.Con)
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
        else if (!item.RandomArtifactItemCharacteristics.Str)
        {
            item.RandomArtifactItemCharacteristics.Str = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }

        return false;
    }
    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.SustCon)
        {
            item.RandomArtifactItemCharacteristics.SustCon = true;
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
            if (!item.RandomArtifactItemCharacteristics.SlayAnimal)
            {
                item.RandomArtifactItemCharacteristics.SlayAnimal = true;
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
        if (SaveGame.DieRoll(20) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CharmAnimalEvery500Activation));
        }
        else if (SaveGame.DieRoll(7) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(SummonAnimalActivation));
        }
        else if (SaveGame.DieRoll(6) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CharmAnimal1xEvery300Activation));
        }
        else if (SaveGame.DieRoll(4) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(ResistAll40p1d40Activation));
        }
        else if (SaveGame.DieRoll(3) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(SatiateActivation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(RemoveFearAndPoisonEvery5Activation));
        }
    }
}
