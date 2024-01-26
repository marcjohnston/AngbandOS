// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatScript : Script, IScript, IRepeatableScript
{
    private EatScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the eat script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the eat script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.SelectItem(out Item? item, "Eat which item? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeEatenItemFilter))))
        {
            SaveGame.MsgPrint("You have nothing to eat.");
            return;
        }
        if (item == null)
        {
            return;
        }

        // Make sure the item is edible
        FoodItem? foodItem = item.TryCast<FoodItem>();
        if (foodItem == null)
        {
            SaveGame.MsgPrint("You can't eat that!");
            return;
        }

        // Eating costs 100 energy
        SaveGame.EnergyUse = 100;
        int itemLevel = item.Factory.Level;

        // Allow the food item to process the consumption.
        bool ident = foodItem.Factory.Eat();

        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();

        // We've tried this type of object
        item.ObjectTried();

        // Learn its flavour if necessary
        if (ident && !item.IsFlavourAware())
        {
            item.BecomeFlavourAware();
            SaveGame.GainExperience((itemLevel + (SaveGame.ExperienceLevel >> 1)) / SaveGame.ExperienceLevel);
        }

        // Now races process the sustenance.
        SaveGame.Race.Eat(foodItem);

        // Dwarf bread isn't actually eaten so return early
        if (!foodItem.Factory.IsConsumedWhenEaten)
        {
            return;
        }

        // Use up the item (if it fell to the floor this will have already been dealt with)
        IItemContainer container = item.GetContainer();
        item.ItemIncrease(-1);
        item.ItemOptimize();
        container.ItemDescribe(item);
        return;
    }
}
