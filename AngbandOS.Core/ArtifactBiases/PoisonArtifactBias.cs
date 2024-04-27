// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class PoisonArtifactBias : ArtifactBias
{
    private PoisonArtifactBias(Game game) : base(game) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.ResPois)
        {
            item.RandomArtifactItemCharacteristics.ResPois = true;
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
        return Game.SingletonRepository.Get<Activation>(nameof(StinkingCloud12Every4p1d4Activation));
    }
}
