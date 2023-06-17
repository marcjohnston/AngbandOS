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
            if (Program.Rng.DieRoll(2) == 1)
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
        if (Program.Rng.DieRoll(13) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<CharmUndeadActivation>();
        }
        else if (Program.Rng.DieRoll(12) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<BanishEvilActivation>();
        }
        else if (Program.Rng.DieRoll(11) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<DispEvilActivation>();
        }
        else if (Program.Rng.DieRoll(10) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<ProtEvilActivation>();
        }
        else if (Program.Rng.DieRoll(9) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<Cure1000Activation>();
        }
        else if (Program.Rng.DieRoll(8) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<Cure700Activation>();
        }
        else if (Program.Rng.DieRoll(7) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<RestAllActivation>();
        }
        else if (Program.Rng.DieRoll(6) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<RestLifeActivation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<CureMwActivation>();
        }
    }
}
