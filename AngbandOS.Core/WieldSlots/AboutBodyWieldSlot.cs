﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.WieldSlots;

[Serializable]
internal class AboutBodyWieldSlot : EquipmentWieldSlot
{
    private AboutBodyWieldSlot(Game game) : base(game) { }
    public override string Label(int index) => "i";
    public override string Label(Item optr) => "i";
    public override int[] InventorySlots => new int[] { InventorySlotEnum.AboutBody };
    public override string MentionUse(int? index) => "About body";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your back";
    public override int BareArmorClassBonus => Game.ExperienceLevel.IntValue > 15 ? (Game.ExperienceLevel.IntValue - 13) / 3 : 0;
    public override bool IsWeightRestricting => true;
    public override bool IsArmor => true;
    public override int SortOrder => 9;
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlotEnum.AboutBody, item);
        Game.WeightCarried += item.Weight;
    }
}