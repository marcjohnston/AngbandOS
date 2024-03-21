// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ColdArtifactBias : ArtifactBias
{
    private ColdArtifactBias(Game game) : base(game) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.ResCold)
        {
            item.RandomArtifactItemCharacteristics.ResCold = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Game.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandomArtifactItemCharacteristics.ImCold)
        {
            item.RandomArtifactItemCharacteristics.ImCold = true;
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
            if (!item.RandomArtifactItemCharacteristics.BrandCold)
            {
                item.RandomArtifactItemCharacteristics.BrandCold = true;
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
        if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(FrostBolt6d8Every7p1d7Activation));
        }
        else if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(BallOfCold48r2Every400Activation));
        }
        else if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(BallOfCold100r2Every300Activation));
        }
        else
        {
            return Game.SingletonRepository.Activations.Get(nameof(LargeFrostBall200Every325p1d325Activation));
        }
    }
}
