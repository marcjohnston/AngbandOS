﻿// AngbandOS: 2022 Marc Johnston
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
    public override string AffinityName => "Poison";
    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistPoisonItemTest), "1", nameof(ResistPoisonItemEnhancement), "1/2")
    };

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomSlayingTuples => new (string, string, string, string)[]
    {
        (nameof(CanSlayAndFalseBrandPoisonItemTest), "1", nameof(BrandPoisonItemEnhancement), "1/2")
    };

    public override Activation GetActivationPowerType()
    {
        return Game.SingletonRepository.Get<Activation>(nameof(StinkingCloud12Every1d4p4DirectionalActivation));
    }
}
