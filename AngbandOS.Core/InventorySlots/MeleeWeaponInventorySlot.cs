// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class MeleeWeaponInventorySlot : EquipmentInventorySlot
{
    private MeleeWeaponInventorySlot(SaveGame saveGame) : base(saveGame) { }
    public override int[] InventorySlots => new int[] { InventorySlot.MeleeWeapon };
    public override int SortOrder => 1;
    public override string Label(int index) => "a";
    public override string Label(Item oPtr) => "a";
    public override bool IsMeleeWeapon => true;
    public override string WieldPhrase => "You are wielding";
    public override string TakeOffMessage(Item oPtr) => "You were wielding";
    public override string MentionUse(int? index)
    {
        string p = "Wielding";
        if (Count > 0 && index.HasValue)
        {
            Item? oPtr = SaveGame.GetInventoryItem(index.Value);
            if (oPtr != null && SaveGame.AbilityScores[Ability.Strength].StrMaxWeaponWeight < oPtr.Weight / 10)
            {
                p = "Just lifting";
            }
        }
        return p;
    }

    public override string DescribeWieldLocation(int index) 
    {
        string p = "attacking monsters with";
        if (Count > 0)
        {
            Item? oPtr = SaveGame.GetInventoryItem(index);
            if (oPtr != null && SaveGame.AbilityScores[Ability.Strength].StrMaxWeaponWeight < oPtr.Weight / 10)
            {
                p = "just lifting";
            }
        }
        return p;
    }

    public override string DescribeItemLocation(Item oPtr)
    {
        string p = "attacking monsters with";

        // Check to see if we have a weapon.
        if (oPtr != null && SaveGame.AbilityScores[Ability.Strength].StrMaxWeaponWeight < oPtr.Weight / 10)
        {
            p = "just lifting";
        }
        return p;
    }
}