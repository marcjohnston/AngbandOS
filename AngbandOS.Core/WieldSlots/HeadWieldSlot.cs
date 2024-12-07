// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WieldSlots;

[Serializable]
internal class HeadWieldSlot : EquipmentWieldSlot
{
    private HeadWieldSlot(Game game) : base(game) { }
    public override string Label(int index) => "k";
    public override string Label(Item oPtr) => "k";
    public override int[] InventorySlots => new int[] { InventorySlotEnum.Head };
    public override string MentionUse(int? index) => "On head";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your head";
    public override int BareArmorClassBonus => (Game.ExperienceLevel.IntValue - 2) / 3;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override int SortOrder => 11;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlotEnum.Head, item);
        Game.WeightCarried += item.Weight;
    }
}