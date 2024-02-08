// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class UseStaffScript : Script, IScript, IRepeatableScript
{
    private UseStaffScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the use staff script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the use staff script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.SelectItem(out Item? item, "Use which staff? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeUsedItemFilter))))
        {
            SaveGame.MsgPrint("You have no staff to use.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Make sure the item is actually a staff
        if (!SaveGame.ItemMatchesFilter(item, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeUsedItemFilter))))
        {
            SaveGame.MsgPrint("That is not a staff!");
            return;
        }

        StaffItemFactory staffItem = (StaffItemFactory)item.Factory;

        // We can't use a staff from the floor
        if (!item.IsInInventory && item.Count > 1)
        {
            SaveGame.MsgPrint("You must first pick up the staff.");
            return;
        }
        // Using a staff costs a full turn
        SaveGame.EnergyUse = 100;
        int itemLevel = item.Factory.Level;
        // We have a chance of the device working equal to skill (halved if confused) - item
        // level (capped at 50)
        int chance = SaveGame.SkillUseDevice;
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            chance /= 2;
        }
        chance -= itemLevel > 50 ? 50 : itemLevel;
        // Always a small chance of it working
        if (chance < Constants.UseDevice && SaveGame.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }
        // Check to see if we use it properly
        if (chance < Constants.UseDevice || SaveGame.Rng.DieRoll(chance) < Constants.UseDevice)
        {
            SaveGame.MsgPrint("You failed to use the staff properly.");
            return;
        }
        // Make sure it has charges left
        if (item.TypeSpecificValue <= 0)
        {
            SaveGame.MsgPrint("The staff has no charges left.");
            item.IdentEmpty = true;
            return;
        }
        SaveGame.PlaySound(SoundEffectEnum.UseStaff);
        UseStaffEvent useStaffEventArgs = new UseStaffEvent();

        // Do the specific effect for the type of staff
        staffItem.UseStaff(useStaffEventArgs);

        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // We might now know what the staff does
        item.ObjectTried();
        if (useStaffEventArgs.Identified && !item.IsFlavorAware())
        {
            item.BecomeFlavorAware();
            SaveGame.GainExperience((itemLevel + (SaveGame.ExperienceLevel >> 1)) / SaveGame.ExperienceLevel);
        }
        // We may not have used up a charge
        if (!useStaffEventArgs.ChargeUsed)
        {
            return;
        }
        // Channelers can use mana instead of a charge
        bool channeled = false;
        if (SaveGame.BaseCharacterClass.SpellCastingType.CanUseManaInsteadOfConsumingItem)
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
                SaveGame.WeightCarried -= singleStaff.Weight;
                SaveGame.InvenCarry(singleStaff);
                SaveGame.MsgPrint("You unstack your staff.");
            }
            // Let the player know what happened
            SaveGame.ReportChargeUsage(item);
        }
    }
}
