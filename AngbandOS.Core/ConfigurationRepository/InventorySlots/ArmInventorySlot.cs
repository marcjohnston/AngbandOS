// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class ArmInventorySlot : EquipmentInventorySlot
{
    private ArmInventorySlot(SaveGame saveGame) : base(saveGame) { }
    public override int[] InventorySlots => new int[] { InventorySlot.Arm };
    public override string Label(int index) => "j";
    public override string Label(Item oPtr) => "j";
    public override string MentionUse(int? index) => "On arm";
    public override string DescribeWieldLocation(int index) => "wearing on your arm";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your arm";
    public override int BareArmorClassBonus => SaveGame.ExperienceLevel > 10 ? (SaveGame.ExperienceLevel - 8) / 3 : 0;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override int SortOrder => 10;
}