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
    public override string AffinityName => "Cold";

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistColdItemFilter), "1", nameof(ResistColdItemEnhancement), "1/2"),
        (nameof(FalseColdImmunityItemFilter), "1/20", nameof(ColdImmunityItemEnhancement), "1/2")
    };

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomSlayingTuples => new (string, string, string, string)[]
    {
        (nameof(CanSlayAndFalseBrandColdItemFilter), "1", nameof(BrandColdItemEnhancement), "1/2")
    };

    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(FrostBolt6d8Every7p1d7DirectionalActivation));
        }
        else if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BallOfCold48r2Every400DirectionalActivation));
        }
        else if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BallOfCold100r2Every300DirectionalActivation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(LargeFrostBall200Every325p1d325DirectionalActivation));
        }
    }
}
