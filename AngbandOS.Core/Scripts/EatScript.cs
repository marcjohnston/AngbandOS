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
    private EatScript(Game game) : base(game) { }

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
        if (!Game.SelectItem(out Item? item, "Eat which item? ", false, true, true, Game.SingletonRepository.ItemFilters.Get(nameof(CanBeEatenItemFilter))))
        {
            Game.MsgPrint("You have nothing to eat.");
            return;
        }
        if (item == null)
        {
            return;
        }

        // Make sure the item is edible
        FoodItemFactory? foodItemFactory = item.TryGetFactory<FoodItemFactory>();
        if (foodItemFactory == null)
        {
            Game.MsgPrint("You can't eat that!");
            return;
        }

        // Eating costs 100 energy
        Game.EnergyUse = 100;
        int itemLevel = item.Factory.LevelNormallyFound;

        // Allow the food item to process the consumption.
        bool ident = foodItemFactory.Eat();

        Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();

        // We've tried this type of object
        item.ObjectTried();

        // Learn its flavor if necessary
        if (ident && !item.IsFlavorAware())
        {
            item.BecomeFlavorAware();
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.Value >> 1)) / Game.ExperienceLevel.Value);
        }

        // Now races process the sustenance.
        Game.Race.Eat(item);

        // Dwarf bread isn't actually eaten so return early
        if (!foodItemFactory.IsConsumedWhenEaten)
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
