// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ChaosArtifactBias : ArtifactBias
{
    private ChaosArtifactBias(Game game) : base(game) { }

    public override string AffinityName => "Chaos";
    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistChaosItemTest), "1", nameof(ResistChaosItemEnhancement), "1/2"),
        (nameof(FalseResistConfusionItemTest), "1", nameof(ResistConfusionItemEnhancement), "1/2"),
        (nameof(FalseResistDisenchantItemTest), "1", nameof(ResistDisenchantItemEnhancement), "1/2")
    };

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomSlayingTuples => new (string, string, string, string)[]
    {
        (nameof(FalseChaoticItemTest), "1", nameof(ChaoticItemEnhancement), "1/2")
    };

    public override bool ApplyMiscPowers(RwItemPropertySet characteristics)
    {
        if (!characteristics.Teleport)
        {
            characteristics.Teleport = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
    public override int ActivationPowerChance => 50;

    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SummonFriendlyDemon2In3Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(CallChaosEvery350Activation));
        }
    }
}
