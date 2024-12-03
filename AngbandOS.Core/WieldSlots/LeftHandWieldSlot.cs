// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class LeftHandWieldSlot : EquipmentWieldSlot
{
    private LeftHandWieldSlot(Game game) : base(game) { }
    public override int[] InventorySlots => new int[] { InventorySlot.LeftHand };
    public override string Label(int index) => "d";
    public override string Label(Item oPtr) => "d";
    public override string MentionUse(int? index) => "On left hand";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your left hand";
    public override string DescribeWieldLocation(int index) => "wearing on your left hand";
    public override int SortOrder => 4;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlot.LeftHand, item);
        Game.WeightCarried += item.Weight;
    }
}