// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class LawArtifactBias : ArtifactBias
{
    private LawArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplySlaying(Item item)
    {
        if (item.Category != ItemTypeEnum.Bow)
        {
            if (!item.RandartItemCharacteristics.SlayEvil)
            {
                item.RandartItemCharacteristics.SlayEvil = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.SlayUndead)
            {
                item.RandartItemCharacteristics.SlayUndead = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.SlayDemon)
            {
                item.RandartItemCharacteristics.SlayDemon = true;
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
        if (Program.Rng.DieRoll(8) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<BanishEvilActivation>();
        }
        else if (Program.Rng.DieRoll(4) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<DispEvilActivation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<ProtEvilActivation>();
        }
    }
}
