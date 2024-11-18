// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class AmuletJeweleryItemFactory : JewelleryItemFactory
{
    public AmuletJeweleryItemFactory(Game game) : base(game) { }

    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because amulets are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string ItemClassBindingKey => nameof(AmuletsItemClass);
    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(NeckInventorySlot) };
    public override int PackSort => 17;
    public override int BaseValue => 45;
    public override ColorEnum Color => ColorEnum.Orange;
}
