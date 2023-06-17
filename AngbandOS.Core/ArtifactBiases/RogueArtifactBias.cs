// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class RogueArtifactBias : ArtifactBias
{
    private RogueArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandartItemCharacteristics.Stealth)
        {
            item.RandartItemCharacteristics.Stealth = true;
            if (Program.Rng.DieRoll(2) == 1)
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
            if (!item.RandartItemCharacteristics.BrandPois)
            {
                item.RandartItemCharacteristics.BrandPois = true;
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
        if (Program.Rng.DieRoll(50) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<SpeedActivation>();
        }
        else if (Program.Rng.DieRoll(4) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<SleepActivation>();
        }
        else if (Program.Rng.DieRoll(3) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<DetectAllActivation>();
        }
        else if (Program.Rng.DieRoll(8) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<IdFullActivation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<IdPlainActivation>();
        }
    }
}
