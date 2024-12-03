// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class NeckWieldSlot : EquipmentWieldSlot
{
    private NeckWieldSlot(Game game) : base(game) { }
    public override int[] InventorySlots => new int[] { InventorySlot.Neck };
    public override string Label(int index) => "f";
    public override string Label(Item oPtr) => "f";
    public override string MentionUse(int? index) => "Around neck";
    public override string DescribeItemLocation(Item oPtr) => "wearing around your neck";
    public override int SortOrder => 6;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlot.Neck, item);
        Game.WeightCarried += item.Weight;
    }
}