// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VorpalAndWarriorArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Vorpal1InChance => 2;
    public override int VorpalExtraAttacks1InChance => 2;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Warrior1In9ArtifactBiasWeightedRandom);
    public override string[]? ApplicableItemFactoryBindingKeys => new string[]
    {
        nameof(BastardSwordWeaponItemFactory),
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
    public override int Value => 5000;
}
