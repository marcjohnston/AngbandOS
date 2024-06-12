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
    private UseStaffScript(Game game) : base(game) { }

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
        if (!Game.SelectItem(out Item? item, "Use which staff? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeUsedItemFilter))))
        {
            Game.MsgPrint("You have no staff to use.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Make sure the item is actually a staff
        if (!Game.ItemMatchesFilter(item, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeUsedItemFilter))))
        {
            Game.MsgPrint("That is not a staff!");
            return;
        }

        StaffItemFactory staffItem = (StaffItemFactory)item.Factory;

        // We can't use a staff from the floor
        if (!item.IsInInventory && item.Count > 1)
        {
            Game.MsgPrint("You must first pick up the staff.");
            return;
        }
        // Using a staff costs a full turn
        Game.EnergyUse = 100;
        int itemLevel = item.Factory.LevelNormallyFound;
        // We have a chance of the device working equal to skill (halved if confused) - item
        // level (capped at 50)
        int chance = Game.SkillUseDevice;
        if (Game.ConfusedTimer.Value != 0)
        {
            chance /= 2;
        }
        chance -= itemLevel > 50 ? 50 : itemLevel;
        // Always a small chance of it working
        if (chance < Constants.UseDevice && Game.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }
        // Check to see if we use it properly
        if (chance < Constants.UseDevice || Game.DieRoll(chance) < Constants.UseDevice)
        {
            Game.MsgPrint("You failed to use the staff properly.");
            return;
        }
        // Make sure it has charges left
        if (item.StaffChargesRemaining <= 0)
        {
            Game.MsgPrint("The staff has no charges left.");
            item.IdentEmpty = true;
            return;
        }
        Game.PlaySound(SoundEffectEnum.UseStaff);
        UseStaffEvent useStaffEventArgs = new UseStaffEvent();

        // Do the specific effect for the type of staff
        staffItem.UseStaff(useStaffEventArgs);

        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // We might now know what the staff does
        item.ObjectTried();
        if (useStaffEventArgs.Identified && !item.Factory.IsFlavorAware)
        {
            item.Factory.IsFlavorAware = true;
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.IntValue >> 1)) / Game.ExperienceLevel.IntValue);
        }
        // We may not have used up a charge
        if (!useStaffEventArgs.ChargeUsed)
        {
            return;
        }
        // Channelers can use mana instead of a charge
        bool channeled = false;
        if (Game.BaseCharacterClass.CanUseManaInsteadOfConsumingItem)
        {
            channeled = Game.DoCmdChannel(item);
        }
        if (!channeled)
        {
            // Use the actual charge
            item.StaffChargesRemaining--;
            // If the staff was part of a stack, separate it from the rest
            if (item.IsInInventory && item.Count > 1)
            {
                Item singleStaff = item.Clone(1);
                item.StaffChargesRemaining++;
                item.Count--;
                Game.WeightCarried -= singleStaff.Weight;
                Game.InvenCarry(singleStaff);
                Game.MsgPrint("You unstack your staff.");
            }
            // Let the player know what happened
            if (item.IsKnown())
            {
                if (item.IsInInventory)
                {
                    Game.MsgPrint(item.StaffChargesRemaining != 1 ? $"You have {item.StaffChargesRemaining} charges remaining." : $"You have {item.StaffChargesRemaining} charge remaining.");
                }
                else
                {
                    Game.MsgPrint(item.StaffChargesRemaining != 1 ? $"There are {item.StaffChargesRemaining} charges remaining." : $"There is {item.StaffChargesRemaining} charge remaining.");
                }
            }
        }
    }
}
