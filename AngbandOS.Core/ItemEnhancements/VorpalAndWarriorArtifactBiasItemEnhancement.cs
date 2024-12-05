// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class VorpalAndWarriorArtifactBiasItemEnhancement : ItemEnhancement
{
    private VorpalAndWarriorArtifactBiasItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool Vorpal => true;
    protected override string? ArtifactBiasWeightedRandomBindingKey => nameof(Warrior1In9ArtifactBiasWeightedRandom);
    protected override string[]? ApplicableItemFactoryBindingKeys => new string[]
    {
        nameof(BastardSwordSwordWeaponItemFactory),
        nameof(BladeOfChaosWeaponItemFactory),
        nameof(BroadSwordWeaponItemFactory),
        nameof(BrokenDaggerWeaponItemFactory),
        nameof(BrokenSwordWeaponItemFactory),
        nameof(CutlassWeaponItemFactory),
        nameof(DaggerWeaponItemFactory),
        nameof(ExecutionersSwordWeaponItemFactory),
        nameof(KatanaWeaponItemFactory),
        nameof(LongSwordWeaponItemFactory),
        nameof(MainGaucheWeaponItemFactory),
        nameof(RapierWeaponItemFactory),
        nameof(SabreWeaponItemFactory),
        nameof(ScimitarWeaponItemFactory),
        nameof(ShortSwordWeaponItemFactory),
        nameof(SmallSwordWeaponItemFactory),
        nameof(TulwarWeaponItemFactory),
        nameof(TwoHandedSwordWeaponItemFactory)
    };
}
