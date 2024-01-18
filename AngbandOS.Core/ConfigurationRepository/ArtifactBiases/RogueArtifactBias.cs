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
            if (!item.RandartItemCharacteristics.BrandPois)
            {
                item.RandartItemCharacteristics.BrandPois = true;
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
        if (SaveGame.Rng.DieRoll(50) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(SpeedActivation));
        }
        else if (SaveGame.Rng.DieRoll(4) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(SleepActivation));
        }
        else if (SaveGame.Rng.DieRoll(3) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(DetectAllActivation));
        }
        else if (SaveGame.Rng.DieRoll(8) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(IdFullActivation));
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get(nameof(IdPlainActivation));
        }
    }
}
