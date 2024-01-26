// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AimWandScript : Script, IScript, IRepeatableScript, ISuccessfulScript
{
    private AimWandScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the aim wand script, disposes of the successful result and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteSuccessfulScript();
        return false;
    }

    /// <summary>
    /// Executes the aim wand script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }

    /// <summary>
    /// Executes the aim wand script and returns a success result.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        // Prompt for an item, showing only wands
        if (!SaveGame.SelectItem(out Item? item, "Aim which wand? ", true, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeAimedItemFilter))))
        {
            SaveGame.MsgPrint("You have no wand to aim.");
            return false;
        }
        // Get the item and check if it is really a wand
        if (item == null)
        {
            return false;
        }
        if (!SaveGame.ItemMatchesFilter(item, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeAimedItemFilter))))
        {
            SaveGame.MsgPrint("That is not a wand!");
            return false;
        }
        // We can't use wands directly from the floor, since we need to aim them
        if (!item.IsInInventory && item.Count > 1)
        {
            SaveGame.MsgPrint("You must first pick up the wand.");
            return false;
        }
        // Aim the wand
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return false;
        }
        // Using a wand takes 100 energy
        SaveGame.EnergyUse = 100;
        bool ident = false;
        int itemLevel = item.Factory.Level;
        // Chance of success is your skill - item level, with item level capped at 50 and your
        // skill halved if you're confused
        int chance = SaveGame.SkillUseDevice;
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            chance /= 2;
        }
        chance -= itemLevel > 50 ? 50 : itemLevel;
        // Always a small chance of success
        if (chance < Constants.UseDevice && SaveGame.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
        {
            chance = Constants.UseDevice;
        }
        if (chance < Constants.UseDevice || SaveGame.Rng.DieRoll(chance) < Constants.UseDevice)
        {
            SaveGame.MsgPrint("You failed to use the wand properly.");
            return false;
        }
        // Make sure we have charges
        if (item.TypeSpecificValue <= 0)
        {
            SaveGame.MsgPrint("The wand has no charges left.");
            item.IdentEmpty = true;
            return false;
        }
        SaveGame.PlaySound(SoundEffectEnum.ZapRod);
        WandItemFactory activateableItem = (WandItemFactory)item.Factory;
        if (activateableItem.ExecuteActivation(SaveGame, dir))
        {
            ident = true;
        }

        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // Mark the wand as having been tried
        item.ObjectTried();
        // If we just discovered the item's flavour, mark it as so
        if (ident && !item.IsFlavourAware())
        {
            item.BecomeFlavourAware();
            SaveGame.GainExperience((itemLevel + (SaveGame.ExperienceLevel >> 1)) / SaveGame.ExperienceLevel);
        }
        // If we're a channeler then we should be using mana instead of charges
        bool channeled = false;
        if (SaveGame.BaseCharacterClass.SpellCastingType.CanUseManaInsteadOfConsumingItem)
        {
            channeled = SaveGame.DoCmdChannel(item);
        }
        // We didn't use mana, so decrease the wand's charges
        if (!channeled)
        {
            item.TypeSpecificValue--;
            // If the wand is part of a stack, split it off from the others
            if (item.IsInInventory && item.Count > 1)
            {
                Item splitItem = item.Clone(1);
                item.TypeSpecificValue++;
                item.Count--;
                SaveGame.WeightCarried -= splitItem.Weight;
                SaveGame.InvenCarry(splitItem);
                SaveGame.MsgPrint("You unstack your wand.");
            }
            // Let us know we have used a charge
            SaveGame.ReportChargeUsage(item);
        }
        return true;
    }
}
