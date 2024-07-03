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

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistElectricityItemTest), "1", nameof(ResistElectricityItemAdditiveBundle), "1/2"),
        (nameof(FalseSheathOfElectricityItemTest), "1", nameof(SheathOfElectricityItemAdditiveBundle), "1/2"),
        (nameof(FalseElectricityImmunityItemTest), "1/20", nameof(ElectricityImmunityItemAdditiveBundle), "1/2")
    };

    public override bool ApplySlaying(RandomArtifactCharacteristics characteristics)
    {
        if (characteristics.CanApplyArtifactBiasSlaying)
        {
            if (!characteristics.BrandElec)
            {
                characteristics.BrandElec = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType()
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
