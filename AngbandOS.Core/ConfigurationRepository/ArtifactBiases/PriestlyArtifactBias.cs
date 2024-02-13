// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class PriestlyArtifactBias : ArtifactBias
{
    private PriestlyArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandartItemCharacteristics.Wis)
        {
            item.RandartItemCharacteristics.Wis = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyBlessedArtifactBias && !item.RandartItemCharacteristics.Blessed)
        {
            item.RandartItemCharacteristics.Blessed = true;
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (SaveGame.DieRoll(13) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CharmUndeadActivation));
        }
        else if (SaveGame.DieRoll(12) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(BanishEvilActivation));
        }
        else if (SaveGame.DieRoll(11) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(DispEvilActivation));
        }
        else if (SaveGame.DieRoll(10) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(ProtEvilActivation));
        }
        else if (SaveGame.DieRoll(9) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(Cure1000Activation));
        }
        else if (SaveGame.DieRoll(8) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(Cure700Activation));
        }
        else if (SaveGame.DieRoll(7) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(RestAllActivation));
        }
        else if (SaveGame.DieRoll(6) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(RestLifeActivation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(CureMwActivation));
        }
    }
}
