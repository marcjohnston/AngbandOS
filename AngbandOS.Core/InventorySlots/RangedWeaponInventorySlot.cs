﻿// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots
{
    [Serializable]
    internal class RangedWeaponInventorySlot : BaseInventorySlot
    {
        public RangedWeaponInventorySlot(SaveGame saveGame) : base(saveGame) { }
        public override string Label(int index) => "b";
        public override bool IsMelee => true;
        public override string WieldPhrase => "You are shooting with";
        public override string MentionUse
        {
            get
            {
                string p = "Shooting";
                if (Count > 0)
                {
                    Item oPtr = this[0];
                    if (SaveGame.Player.AbilityScores[Ability.Strength].StrMaxWeaponWeight < oPtr.Weight / 10)
                    {
                        p = "Just holding";
                    }
                }
                return p;
            }
        }

        public override string DescribeWieldLocation
        {
            get
            {
                string p = "shooting missiles with";
                if (Count > 0)
                {
                    Item oPtr = this[0];
                    if (SaveGame.Player.AbilityScores[Ability.Strength].StrMaxWeaponWeight < oPtr.Weight / 10)
                    {
                        p = "just holding";
                    }
                }
                return p;
            }
        }
    }
}