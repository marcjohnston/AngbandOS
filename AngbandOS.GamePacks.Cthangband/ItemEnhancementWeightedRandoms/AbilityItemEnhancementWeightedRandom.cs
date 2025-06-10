// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AbilityItemEnhancementWeightedRandom : ItemEnhancementWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(FeatherFallItemItemEnhancement), 1),
        (nameof(FreeActionItemEnhancement), 1),
        (nameof(HoldLifeItemEnhancement), 1),
        (nameof(LightsourceRadius3ItemEnhancement), 1),
        (nameof(RegenerationItemEnhancement), 1),
        (nameof(SeeInvisibleItemEnhancement), 1),
        (nameof(SlowDigestItemEnhancement), 1),
        (nameof(TelepathyItemEnhancement), 1)
    };
}
