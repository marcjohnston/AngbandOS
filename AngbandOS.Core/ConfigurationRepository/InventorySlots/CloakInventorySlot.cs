﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class CloakInventorySlot : EquipmentInventorySlot
{
    private CloakInventorySlot(SaveGame saveGame) : base(saveGame) { }
    public override string Label(int index) => "i";
    public override string Label(Item optr) => "i";
    public override int[] InventorySlots => new int[] { InventorySlot.Cloak };
    public override string MentionUse(int? index) => "About body";
    public override string DescribeWieldLocation(int index) => "wearing on your back";
    public override string DescribeItemLocation(Item oPtr) => "wearing on your back";
    public override int BareArmourClassBonus => SaveGame.ExperienceLevel > 15 ? (SaveGame.ExperienceLevel - 13) / 3 : 0;
    public override bool IsWeightRestricting => true;
    public override bool IsArmour => true;
    public override int SortOrder => 9;
}