﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class UseStaffScript : Script
    {
        private UseStaffScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            if (!SaveGame.SelectItem(out Item? item, "Use which staff? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Staff)))
            {
                SaveGame.MsgPrint("You have no staff to use.");
                return false;
            }
            if (item == null)
            {
                return false;
            }
            // Make sure the item is actually a staff
            if (!SaveGame.Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Staff)))
            {
                SaveGame.MsgPrint("That is not a staff!");
                return false;
            }

            StaffItemClass staffItem = (StaffItemClass)item.Factory;

            // We can't use a staff from the floor
            if (!item.IsInInventory && item.Count > 1)
            {
                SaveGame.MsgPrint("You must first pick up the staff.");
                return false;
            }
            // Using a staff costs a full turn
            SaveGame.EnergyUse = 100;
            int itemLevel = item.Factory.Level;
            // We have a chance of the device working equal to skill (halved if confused) - item
            // level (capped at 50)
            int chance = SaveGame.Player.SkillUseDevice;
            if (SaveGame.Player.TimedConfusion.TurnsRemaining != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always a small chance of it working
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // Check to see if we use it properly
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                SaveGame.MsgPrint("You failed to use the staff properly.");
                return false;
            }
            // Make sure it has charges left
            if (item.TypeSpecificValue <= 0)
            {
                SaveGame.MsgPrint("The staff has no charges left.");
                item.IdentEmpty = true;
                return false;
            }
            SaveGame.PlaySound(SoundEffect.UseStaff);
            UseStaffEvent useStaffEventArgs = new UseStaffEvent(SaveGame);

            // Do the specific effect for the type of staff
            staffItem.UseStaff(useStaffEventArgs);

            SaveGame.NoticeCombineAndReorderFlaggedAction.Set();
            // We might now know what the staff does
            item.ObjectTried();
            if (useStaffEventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                SaveGame.Player.GainExperience((itemLevel + (SaveGame.Player.Level >> 1)) / SaveGame.Player.Level);
            }
            // We may not have used up a charge
            if (!useStaffEventArgs.ChargeUsed)
            {
                return false;
            }
            // Channelers can use mana instead of a charge
            bool channeled = false;
            if (SaveGame.Player.BaseCharacterClass.SpellCastingType.CanUseManaInsteadOfConsumingItem)
            {
                channeled = SaveGame.DoCmdChannel(item);
            }
            if (!channeled)
            {
                // Use the actual charge
                item.TypeSpecificValue--;
                // If the staff was part of a stack, separate it from the rest
                if (item.IsInInventory && item.Count > 1)
                {
                    Item singleStaff = item.Clone(1);
                    item.TypeSpecificValue++;
                    item.Count--;
                    SaveGame.Player.WeightCarried -= singleStaff.Weight;
                    SaveGame.Player.InvenCarry(singleStaff);
                    SaveGame.MsgPrint("You unstack your staff.");
                }
                // Let the player know what happened
                SaveGame.ReportChargeUsage(item);
            }
            return false;
        }
    }
}