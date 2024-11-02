// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class FeetInventorySlot : EquipmentInventorySlot
{
    private FeetInventorySlot(Game game) : base(game) { }
    public override string Label(int index) => "m";
    public override string Label(Item oPtr) => "m";
    public override int[] InventorySlots => new int[] { InventorySlot.Feet };
    public override string MentionUse(int? index) => "On feet";
    public override string DescribeWieldLocation(int index) => "wearing on your feet";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your feet";
    public override int BareArmorClassBonus => Game.ExperienceLevel.IntValue / 3;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override int SortOrder => 13;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlot.Feet, item);
        Game.WeightCarried += item.Weight;
    }
}