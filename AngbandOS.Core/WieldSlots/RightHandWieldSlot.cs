// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class RightHandWieldSlot : EquipmentWieldSlot
{
    private RightHandWieldSlot(Game game) : base(game) { }
    public override string Label(int index) => "e";
    public override string Label(Item oPtr) => "e";
    public override int[] InventorySlots => new int[] { InventorySlot.RightHand };
    public override string MentionUse(int? index) => "On right hand";
    public override string DescribeWieldLocation(int index) => "wearing on your right hand";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your right hand";
    public override int SortOrder => 5;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlot.RightHand, item);
        Game.WeightCarried += item.Weight;
    }
}