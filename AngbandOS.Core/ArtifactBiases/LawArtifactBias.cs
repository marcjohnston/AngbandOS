// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class LawArtifactBias : ArtifactBias
{
    private LawArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Law";
    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomSlayingTuples => new (string, string, string, string)[]
    {
        (nameof(CanSlayAndFalseSlayEvilItemFilter), "1", nameof(SlayEvilItemEnhancement), "1/2"),
        (nameof(CanSlayAndFalseSlayUndeadItemFilter), "1", nameof(SlayUndeadItemEnhancement), "1/2"),
        (nameof(CanSlayAndFalseSlayDemonItemFilter), "1", nameof(SlayDemonItemEnhancement), "1/2")
    };
    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BanishEvilEvery250p1d250Activation));
        }
        else if (Game.DieRoll(4) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(DispelEvil5xEvery300p1d300Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(ProtectionFromEvilActivation));
        }
    }
}
