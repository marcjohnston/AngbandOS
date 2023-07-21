// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class HeadInventorySlot : EquipmentInventorySlot
{
    private HeadInventorySlot(SaveGame saveGame) : base(saveGame) { }
    public override string Label(int index) => "k";
    public override string Label(Item oPtr) => "k";
    public override int[] InventorySlots => new int[] { InventorySlot.Head };
    public override string MentionUse(int? index) => "On head";
    public override string DescribeWieldLocation(int index) => "wearing on your head";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your head";
    public override int BareArmourClassBonus => (SaveGame.Player.ExperienceLevel - 2) / 3;
    public override bool IsWeightRestricting => true;
    public override bool IsArmour => true;
    public override int SortOrder => 11;
}