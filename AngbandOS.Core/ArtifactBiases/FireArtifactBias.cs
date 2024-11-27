// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class FireArtifactBias : ArtifactBias
{
    private FireArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Fire";
    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistFireItemTest), "1", nameof(ResistFireItemEnhancement), "1/2"),
        (nameof(FalseSheathOfFireItemTest), "1", nameof(SheathOfFireItemEnhancement), "1/2"),
        (nameof(FalseFireImmunityItemTest), "1/20", nameof(FireImmunityItemEnhancement), "1/2")
    };

    public override bool ApplyMiscPowers(RandomArtifactCharacteristics characteristics)
    {
        characteristics.Radius = 3;
        return false;
    }

    public override bool ApplySlaying(RandomArtifactCharacteristics characteristics)
    {
        if (characteristics.CanApplyArtifactBiasSlaying)
        {
            if (!characteristics.BrandFire)
            {
                characteristics.BrandFire = true;
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
            return Game.SingletonRepository.Get<Activation>(nameof(FireBolt9d8Every8p1d8Activation));
        }
        else if (Game.DieRoll(5) != 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BallOfFire72r2Every400Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(FireBall120r3Every225p1d225Activation));
        }
    }
}
