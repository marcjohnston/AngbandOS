﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
namespace AngbandOS.Core.WieldSlots;

[Serializable]
internal class RangedWeaponWieldSlot : EquipmentWieldSlot
{
    private RangedWeaponWieldSlot(Game game) : base(game) { }
    public override string Label(int index) => "b";
    public override string Label(Item oPtr) => "b";
    public override int[] InventorySlots => new int[] { InventorySlotEnum.RangedWeapon };
    public override bool IsRangedWeapon => true;
    public override string WieldPhrase => "You are shooting with";
    public override int SortOrder => 2;
    public override string TakeOffMessage(Item oPtr) => "You were holding";
    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlotEnum.RangedWeapon, item);
        Game.WeightCarried += item.EffectivePropertySet.Weight;
    }
    public override string MentionUse(int? index)
    {
        string p = "Shooting";
        if (Count > 0 && index.HasValue)
        {
            Item? oPtr = Game.GetInventoryItem(index.Value);
            if (oPtr != null && Game.StrengthAbility.StrMaxWeaponWeight < oPtr.EffectivePropertySet.Weight / 10)
            {
                p = "Just holding";
            }
        }
        return p;
    }

    public override string DescribeItemLocation(Item oPtr)
    {
        string p = "shooting missiles with";
        if (oPtr != null && Game.StrengthAbility.StrMaxWeaponWeight < oPtr.EffectivePropertySet.Weight / 10)
        {
            p = "just holding";
        }
        return p;
    }
}