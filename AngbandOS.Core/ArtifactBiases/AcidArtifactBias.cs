﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class AcidArtifactBias : ArtifactBias
{
    private AcidArtifactBias(Game game) : base(game) { }

    public override string AffinityName => "Acid";

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistAcidItemTest), "1", nameof(ResistAcidItemEnhancement), "1/2"),
        (nameof(FalseAcidImmunityItemTest), "1/20", nameof(AcidImmunityAndAcidArtifactBiasItemEnhancement), "1/2")
    };

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomSlayingTuples => new (string, string, string, string)[]
    {
        (nameof(CanSlayAndFalseBrandAcidItemTest), "1", nameof(BrandAcidItemEnhancement), "1/2")
    };
}
