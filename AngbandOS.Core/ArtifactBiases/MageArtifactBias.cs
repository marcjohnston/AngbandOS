// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class MageArtifactBias : ArtifactBias
{
    private MageArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandartItemCharacteristics.Int)
        {
            item.RandartItemCharacteristics.Int = true;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override int ActivationPowerChance => 66;

    public override Activation GetActivationPowerType(Item item)
    {
        if (Program.Rng.DieRoll(20) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<SummonElementalActivation>();
        }
        else if (Program.Rng.DieRoll(10) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<SummonPhantomActivation>();
        }
        else if (Program.Rng.DieRoll(5) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<RuneExploActivation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<EspActivation>();
        }
    }
}
