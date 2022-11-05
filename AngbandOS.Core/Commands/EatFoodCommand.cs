using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;
using AngbandOS.ItemCategories;
using AngbandOS.Core;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Eat some food
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the food item </param>
    [Serializable]
    internal class EatFoodCommand : ICommand
    {
        public char Key => 'E';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;
            // Get a food item from the inventory if one wasn't already specified
            Inventory.ItemFilterCategory = ItemCategory.Food;
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Eat which item? ", false, true, true))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have nothing to eat.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is edible
            Inventory.ItemFilterCategory = ItemCategory.Food;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                saveGame.MsgPrint("You can't eat that!");
                Inventory.ItemFilterCategory = 0;
                return;
            }
            Inventory.ItemFilterCategory = 0;
            // We don't actually eat dwarf bread
            if (item.ItemSubCategory != FoodType.Dwarfbread)
            {
                saveGame.PlaySound(SoundEffect.Eat);
            }
            // Eating costs 100 energy
            saveGame.EnergyUse = 100;
            bool ident = false;
            int itemLevel = item.ItemType.BaseItemCategory.Level;
            switch (item.ItemSubCategory)
            {
                case FoodType.Poison:
                    {
                        if (!(saveGame.Player.HasPoisonResistance || saveGame.Player.TimedPoisonResistance != 0))
                        {
                            // Hagarg Ryonis may protect us from poison
                            if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                            {
                                saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                            }
                            else if (saveGame.Player.SetTimedPoison(saveGame.Player.TimedPoison + Program.Rng.RandomLessThan(10) + 10))
                            {
                                ident = true;
                            }
                        }
                        break;
                    }
                case FoodType.Blindness:
                    {
                        if (!saveGame.Player.HasBlindnessResistance)
                        {
                            if (saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + Program.Rng.RandomLessThan(200) + 200))
                            {
                                ident = true;
                            }
                        }
                        break;
                    }
                case FoodType.Paranoia:
                    {
                        if (!saveGame.Player.HasFearResistance)
                        {
                            if (saveGame.Player.SetTimedFear(saveGame.Player.TimedFear + Program.Rng.RandomLessThan(10) + 10))
                            {
                                ident = true;
                            }
                        }
                        break;
                    }
                case FoodType.Confusion:
                    {
                        if (!saveGame.Player.HasConfusionResistance)
                        {
                            if (saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.RandomLessThan(10) + 10))
                            {
                                ident = true;
                            }
                        }
                        break;
                    }
                case FoodType.Hallucination:
                    {
                        if (!saveGame.Player.HasChaosResistance)
                        {
                            if (saveGame.Player.SetTimedHallucinations(saveGame.Player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 250))
                            {
                                ident = true;
                            }
                        }
                        break;
                    }
                case FoodType.Paralysis:
                    {
                        if (!saveGame.Player.HasFreeAction)
                        {
                            if (saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.RandomLessThan(10) + 10))
                            {
                                ident = true;
                            }
                        }
                        break;
                    }
                case FoodType.Weakness:
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(6, 6), "poisonous food.");
                        saveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
                        ident = true;
                        break;
                    }
                case FoodType.Sickness:
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(6, 6), "poisonous food.");
                        saveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
                        ident = true;
                        break;
                    }
                case FoodType.Stupidity:
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), "poisonous food.");
                        saveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                        ident = true;
                        break;
                    }
                case FoodType.Naivety:
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), "poisonous food.");
                        saveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
                        ident = true;
                        break;
                    }
                case FoodType.Unhealth:
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(10, 10), "poisonous food.");
                        saveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
                        ident = true;
                        break;
                    }
                case FoodType.Disease:
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(10, 10), "poisonous food.");
                        saveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
                        ident = true;
                        break;
                    }
                case FoodType.CurePoison:
                    {
                        if (saveGame.Player.SetTimedPoison(0))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.CureBlindness:
                    {
                        if (saveGame.Player.SetTimedBlindness(0))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.CureParanoia:
                    {
                        if (saveGame.Player.SetTimedFear(0))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.CureConfusion:
                    {
                        if (saveGame.Player.SetTimedConfusion(0))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.CureSerious:
                    {
                        if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8)))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.RestoreStr:
                    {
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Strength))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.RestoreCon:
                    {
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Constitution))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.Restoring:
                    {
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Strength))
                        {
                            ident = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
                        {
                            ident = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom))
                        {
                            ident = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity))
                        {
                            ident = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Constitution))
                        {
                            ident = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Charisma))
                        {
                            ident = true;
                        }
                        break;
                    }
                case FoodType.Ration:
                case FoodType.Biscuit:
                case FoodType.Jerky:
                    {
                        saveGame.MsgPrint("That tastes good.");
                        ident = true;
                        break;
                    }
                case FoodType.Dwarfbread:
                    {
                        saveGame.MsgPrint("You look at the dwarf bread, and don't feel quite so hungry anymore.");
                        ident = true;
                        break;
                    }
                case FoodType.SlimeMold:
                    {
                        PotionItemCategory slimeMold = new PotionSlimeMoldJuice();
                        slimeMold.Quaff(saveGame);
                        ident = true;
                        break;
                    }
                case FoodType.Waybread:
                    {
                        saveGame.MsgPrint("That tastes good.");
                        saveGame.Player.SetTimedPoison(0);
                        saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8));
                        ident = true;
                        break;
                    }
                case FoodType.PintOfAle:
                case FoodType.PintOfWine:
                    {
                        saveGame.MsgPrint("That tastes good.");
                        ident = true;
                        break;
                    }
                case FoodType.Warpstone:
                    {
                        saveGame.MsgPrint("That tastes... funky.");
                        saveGame.Player.Dna.GainMutation(saveGame);
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            saveGame.Player.Dna.GainMutation(saveGame);
                        }
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            saveGame.Player.Dna.GainMutation(saveGame);
                        }
                        ident = true;
                        break;
                    }
            }
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We've tried this type of object
            item.ObjectTried();
            // Learn its flavour if necessary
            if (ident && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // Dwarf bread isn't actually eaten so reduce our hunger and return early
            if (item.ItemSubCategory == FoodType.Dwarfbread)
            {
                saveGame.Player.SetFood(saveGame.Player.Food + item.TypeSpecificValue);
                return;
            }
            // Vampires only get 1/10th of the food value
            if (saveGame.Player.RaceIndex == RaceId.Vampire)
            {
                _ = saveGame.Player.SetFood(saveGame.Player.Food + (item.TypeSpecificValue / 10));
                saveGame.MsgPrint("Mere victuals hold scant sustenance for a being such as yourself.");
                if (saveGame.Player.Food < Constants.PyFoodAlert)
                {
                    saveGame.MsgPrint("Your hunger can only be satisfied with fresh blood!");
                }
            }
            // Skeletons get no food sustenance
            else if (saveGame.Player.RaceIndex == RaceId.Skeleton)
            {
                if (!(item.ItemSubCategory == FoodType.Waybread || item.ItemSubCategory == FoodType.Warpstone ||
                      item.ItemSubCategory < FoodType.Biscuit))
                {
                    // Spawn a new food item on the floor to make up for the one that will be destroyed
                    Item floorItem = new Item(saveGame);
                    saveGame.MsgPrint("The food falls through your jaws!");
                    floorItem.AssignItemType(item.ItemType);
                    saveGame.Level.DropNear(floorItem, -1, saveGame.Player.MapY, saveGame.Player.MapX);
                }
                else
                {
                    // But some magical types work anyway and then vanish
                    saveGame.MsgPrint("The food falls through your jaws and vanishes!");
                }
            }
            // Golems, zombies, and spectres get only 1/20th of the food value
            else if (saveGame.Player.RaceIndex == RaceId.Golem || saveGame.Player.RaceIndex == RaceId.Zombie || saveGame.Player.RaceIndex == RaceId.Spectre)
            {
                saveGame.MsgPrint("The food of mortals is poor sustenance for you.");
                saveGame.Player.SetFood(saveGame.Player.Food + (item.TypeSpecificValue / 20));
            }
            // Everyone else gets the full value
            else
            {
                saveGame.Player.SetFood(saveGame.Player.Food + item.TypeSpecificValue);
            }
            // Use up the item (if it fell to the floor this will have already been dealt with)
            if (itemIndex >= 0)
            {
                saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -1);
                saveGame.Player.Inventory.InvenItemDescribe(itemIndex);
                saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
            }
            else
            {
                saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                saveGame.Level.FloorItemDescribe(0 - itemIndex);
                saveGame.Level.FloorItemOptimize(0 - itemIndex);
            }
        }
    }
}
