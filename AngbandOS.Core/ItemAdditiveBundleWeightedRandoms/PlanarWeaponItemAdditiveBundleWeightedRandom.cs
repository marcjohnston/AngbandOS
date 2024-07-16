// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal class PlanarWeaponItemAdditiveBundleWeightedRandom : ItemAdditiveBundleWeightedRandom
{
    private PlanarWeaponItemAdditiveBundleWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemAdditiveBundleNames => new (string?, int)[]
    {
        (nameof(FeatherFallItemItemAdditiveBundle), 1),
        (nameof(FreeActionItemAdditiveBundle), 1),
        (nameof(HoldLifeItemAdditiveBundle), 1),
        (nameof(LightsourceRadius3ItemAdditiveBundle), 1),
        (nameof(RegenerationItemAdditiveBundle), 1),
        (nameof(SeeInvisibleItemAdditiveBundle), 1),
        (nameof(SlowDigestItemAdditiveBundle), 1),
        (nameof(TelepathyItemAdditiveBundle), 1),
        (null, 56)
    };
}
