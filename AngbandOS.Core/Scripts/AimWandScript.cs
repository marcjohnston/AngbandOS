// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AimWandScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private AimWandScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the aim wand script, disposes of the successful result and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the aim wand script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Prompt for an item, showing only wands
        if (!Game.SelectItem(out Item? item, "Aim which wand? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeAimedItemFilter))))
        {
            Game.MsgPrint("You have no wand to aim.");
            return;
        }
        // Get the item and check if it is really a wand
        if (item == null)
        {
            return;
        }
        if (item.AimingTuple == null)
        {
            Game.MsgPrint("That is not a wand!");
            return;
        }
        // We can't use wands directly from the floor, since we need to aim them
        if (!item.IsInInventory && item.StackCount > 1)
        {
            Game.MsgPrint("You must first pick up the wand.");
            return;
        }
        // Aim the wand
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        // Using a wand takes 100 energy
        Game.EnergyUse = 100;
        int itemLevel = item.LevelNormallyFound;
        // Chance of success is your skill - item level, with item level capped at 50 and your
        // skill halved if you're confused
        int chance = Game.SkillUseDevice;
        if (Game.ConfusionTimer.Value != 0)
        {
            chance /= 2;
        }
        chance -= itemLevel > 50 ? 50 : itemLevel;
        // Always a small chance of success
        if (chance < Constants.UseDevice && Game.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }
        if (chance < Constants.UseDevice || Game.DieRoll(chance) < Constants.UseDevice)
        {
            Game.MsgPrint("You failed to use the wand properly.");
            return; // TODO: This is success = false, and cancel = false.  This should be a cancelable script.
        }
        // Make sure we have charges
        if (item.WandChargesRemaining <= 0)
        {
            Game.MsgPrint("The wand has no charges left.");
            item.IdentEmpty = true;
            return;
        }
        Game.PlaySound(SoundEffectEnum.ZapRod);
        IdentifiedResult identifiedResult = item.AimingTuple.Value.ActivationScript.ExecuteAimWandScript(dir);

        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // Mark the wand as having been tried
        item.ObjectTried();
        // If we just discovered the item's flavor, mark it as so
        if (identifiedResult.IsIdentified && !item.IsFlavorAware)
        {
            item.IsFlavorAware = true;
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.IntValue >> 1)) / Game.ExperienceLevel.IntValue);
        }
        // If we're a channeler then we should be using mana instead of charges
        bool channeled = false;
        if (Game.BaseCharacterClass.CanUseManaInsteadOfConsumingItem)
        {
            channeled = Game.DoCmdChannel(item, item.AimingTuple.Value.ManaValue);
        }
        // We didn't use mana, so decrease the wand's charges
        if (!channeled)
        {
            item.WandChargesRemaining--;
            // If the wand is part of a stack, split it off from the others
            if (item.IsInInventory && item.StackCount > 1)
            {
                Item splitItem = item.TakeFromStack(1);
                item.WandChargesRemaining++;
                Game.WeightCarried -= splitItem.Weight;
                Game.InventoryCarry(splitItem);
                Game.MsgPrint("You unstack your wand.");
            }
            // Let us know we have used a charge
            if (item.IsKnown())
            {
                if (item.IsInInventory)
                {
                    Game.MsgPrint(item.WandChargesRemaining != 1 ? $"You have {item.WandChargesRemaining} charges remaining." : $"You have {item.WandChargesRemaining} charge remaining.");
                }
                else
                {
                    Game.MsgPrint(item.WandChargesRemaining != 1 ? $"There are {item.WandChargesRemaining} charges remaining." : $"There is {item.WandChargesRemaining} charge remaining.");
                }
            }
        }
    }
}
