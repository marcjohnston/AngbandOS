﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatScript : Script
{
    private EatScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        if (!SaveGame.SelectItem(out Item? item, "Eat which item? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Food)))
        {
            SaveGame.MsgPrint("You have nothing to eat.");
            return false;
        }
        if (item == null)
        {
            return false;
        }

        // Make sure the item is edible
        FoodItem? foodItem = item.TryCast<FoodItem>();
        if (foodItem == null)
        {
            SaveGame.MsgPrint("You can't eat that!");
            return false;
        }

        // Eating costs 100 energy
        SaveGame.EnergyUse = 100;
        int itemLevel = item.Factory.Level;

        // Allow the food item to process the consumption.
        bool ident = foodItem.Factory.Eat();

        SaveGame.SingletonRepository.FlaggedActions.Get<NoticeCombineAndReorderGroupSetFlaggedAction>().Set();

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
            return false;
        }

        // Use up the item (if it fell to the floor this will have already been dealt with)
        IItemContainer container = item.GetContainer();
        item.ItemIncrease(-1);
        item.ItemOptimize();
        container.ItemDescribe(item);
        return false;
    }
}