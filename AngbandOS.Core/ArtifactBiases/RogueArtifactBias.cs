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
    private RogueArtifactBias(Game game) : base(game) { }
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.Stealth)
        {
            item.RandomArtifactItemCharacteristics.Stealth = true;
            if (Game.DieRoll(2) == 1)
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
            if (!item.RandomArtifactItemCharacteristics.BrandPois)
            {
                item.RandomArtifactItemCharacteristics.BrandPois = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (Game.DieRoll(50) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Speed20p1d20Every250Activation));
        }
        else if (Game.DieRoll(4) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SleepActivation));
        }
        else if (Game.DieRoll(3) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(DetectionEvery55p1d55Activation));
        }
        else if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(IdentifyFullyEvery750Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(IdentifyItemCancellableScript));
        }
    }
}
