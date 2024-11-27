// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ItemCharacteristicTests;

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class AcidArtifactBias : ArtifactBias
{
    private AcidArtifactBias(Game game) : base(game) { }

    public override string AffinityName => "Acid";

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistAcidItemTest), "1", nameof(ResistAcidItemEnhancement), "1/2"),
        (nameof(FalseAcidImmunityItemTest), "1/20", nameof(AcidImmunityItemEnhancement), "1/2")
    };

    public override bool ApplySlaying(RandomArtifactCharacteristics characteristics)
    {
        if (characteristics.CanApplyArtifactBiasSlaying)
        {
            if (!characteristics.BrandAcid)
            {
                characteristics.BrandAcid = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
