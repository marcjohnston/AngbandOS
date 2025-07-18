﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.WieldSlots;

[Serializable]
internal class ArmWieldSlot : EquipmentWieldSlot
{
    private ArmWieldSlot(Game game) : base(game) { }
    public override int[] InventorySlots => new int[] { InventorySlotEnum.Arm };
    public override string Label(int index) => "j";
    public override string Label(Item oPtr) => "j";
    public override string MentionUse(int? index) => "On arm";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your arm";
    public override int BareArmorClassBonus => Game.ExperienceLevel.IntValue > 10 ? (Game.ExperienceLevel.IntValue - 8) / 3 : 0;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override int SortOrder => 10;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlotEnum.Arm, item);
        Game.WeightCarried += item.Weight;
    }
}