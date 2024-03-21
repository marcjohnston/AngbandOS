// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class OnBodyInventorySlot : EquipmentInventorySlot
{
    private OnBodyInventorySlot(Game game) : base(game) { }
    public override string Label(int index) => "h";
    public override string Label(Item oPtr) => "h";
    public override int[] InventorySlots => new int[] { InventorySlot.OnBody };
    public override string MentionUse(int? index) => "On body";
    public override string DescribeWieldLocation(int index) => "wearing on your body";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your body";
    public override int BareArmorClassBonus => Game.ExperienceLevel.Value * 3 / 2;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override bool CanBeCursed => true;
    public override int SortOrder => 8;
}