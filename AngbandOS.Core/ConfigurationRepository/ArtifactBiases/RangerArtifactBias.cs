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
        if (!item.RandartItemCharacteristics.Con)
        {
            item.RandartItemCharacteristics.Con = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (!item.RandartItemCharacteristics.Dex)
        {
            item.RandartItemCharacteristics.Dex = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (!item.RandartItemCharacteristics.Str)
        {
            item.RandartItemCharacteristics.Str = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }

        return false;
    }
    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.RandartItemCharacteristics.SustCon)
        {
            item.RandartItemCharacteristics.SustCon = true;
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
            if (!item.RandartItemCharacteristics.SlayAnimal)
            {
                item.RandartItemCharacteristics.SlayAnimal = true;
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
        if (SaveGame.Rng.DieRoll(20) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CharmAnimalsActivation));
        }
        else if (SaveGame.Rng.DieRoll(7) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(SummonAnimalActivation));
        }
        else if (SaveGame.Rng.DieRoll(6) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CharmAnimalActivation));
        }
        else if (SaveGame.Rng.DieRoll(4) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(ResistAllActivation));
        }
        else if (SaveGame.Rng.DieRoll(3) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(SatiateActivation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CurePoisonActivation));
        }
    }
}
