// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ElectricityArtifactBias : ArtifactBias
{
    private ElectricityArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Electricity";
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.ResElec)
        {
            item.RandomArtifactItemCharacteristics.ResElec = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (item.Factory.CanApplyArtifactBiasResistance && !item.RandomArtifactItemCharacteristics.ShElec)
        {
            item.RandomArtifactItemCharacteristics.ShElec = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Game.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandomArtifactItemCharacteristics.ImElec)
        {
            item.RandomArtifactItemCharacteristics.ImElec = true;
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
            if (!item.RandomArtifactItemCharacteristics.BrandElec)
            {
                item.RandomArtifactItemCharacteristics.BrandElec = true;
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
            return Game.SingletonRepository.Get<Activation>(nameof(LightningBolt4d8Every6p1d6Activation));
        }
        else if (Game.DieRoll(5) != 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BallOfLightning100r3Every500Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(LargeLightningBall250Every425p1d425Activation));
        }
    }
}
