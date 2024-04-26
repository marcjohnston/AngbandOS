// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ZapRodScript : Script, IScript, IRepeatableScript
{
    private ZapRodScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the zap rod script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the zap rod script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.SelectItem(out Item? item, "Zap which rod? ", false, true, true, Game.SingletonRepository.ItemFilters.Get(nameof(CanBeZappedItemFilter))))
        {
            Game.MsgPrint("You have no rod to zap.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Make sure the item is actually a rod
        if (!Game.ItemMatchesFilter(item, Game.SingletonRepository.ItemFilters.Get(nameof(CanBeZappedItemFilter))))
        {
            Game.MsgPrint("That is not a rod!");
            return;
        }
        // Rods can't be used from the floor
        if (!item.IsInInventory && item.Count > 1)
        {
            Game.MsgPrint("You must first pick up the rods.");
            return;
        }
        // We may need to aim the rod.  If we know that the rod requires aiming, we get a direction from the player.  Otherwise, if we do not know what
        // the rod is going to do, we will get a direction from the player.  This helps prevent the player from learning what the rod does because the game
        // would ask for a direction.
        RodItemFactory rodItemCategory = (RodItemFactory)item.Factory;
        int? dir = 5;
        if (rodItemCategory.RequiresAiming || !item.IsFlavorAware())
        {
            if (!Game.GetDirectionWithAim(out int direction))
            {
                return;
            }
            dir = direction;
        }

        // Using a rod takes a whole turn
        Game.EnergyUse = 100;
        bool identified = false;
        int itemLevel = item.Factory.LevelNormallyFound;
        // Chance to successfully use it is skill (halved if confused) - rod level (capped at 50)
        int chance = Game.SkillUseDevice;
        if (Game.ConfusedTimer.Value != 0)
        {
            chance /= 2;
        }
        chance -= itemLevel > 50 ? 50 : itemLevel;
        // There's always a small chance of success
        if (chance < Constants.UseDevice && Game.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }
        // Do the actual check
        if (chance < Constants.UseDevice || Game.DieRoll(chance) < Constants.UseDevice)
        {
            Game.MsgPrint("You failed to use the rod properly.");
            return;
        }
        // Rods only have a single charge but recharge over time
        if (item.TypeSpecificValue != 0)
        {
            Game.MsgPrint("The rod is still charging.");
            return;
        }
        Game.PlaySound(SoundEffectEnum.ZapRod);
        // Do the rod-specific effect
        bool useCharge = true;
        RodItemFactory rodItem = (RodItemFactory)item.Factory;
        ZapRodEvent zapRodEvent = new ZapRodEvent(item, dir);
        rodItem.Execute(zapRodEvent);
        Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // We may have just discovered what the rod does
        item.ObjectTried();
        if (identified && !item.IsFlavorAware())
        {
            item.BecomeFlavorAware();
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.IntValue >> 1)) / Game.ExperienceLevel.IntValue);
        }
        // We may not have actually used a charge
        if (!useCharge)
        {
            item.TypeSpecificValue = 0;
            return ;
        }

        // Channelers can spend mana instead of a charge
        bool channeled = false;
        if (Game.BaseCharacterClass.CanUseManaInsteadOfConsumingItem)
        {
            channeled = Game.DoCmdChannel(item);
            if (channeled)
            {
                item.TypeSpecificValue = 0;
            }
        }

        if (!channeled)
        {
            // If the rod was part of a stack, remove it
            if (item.IsInInventory && item.Count > 1)
            {
                Item singleRod = item.Clone(1);
                item.TypeSpecificValue = 0;
                item.Count--;
                Game.WeightCarried -= singleRod.Weight;
                Game.InvenCarry(singleRod);
                Game.MsgPrint("You unstack your rod.");
            }
        }
    }
}
