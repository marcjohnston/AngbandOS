﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatScript : UniversalScript, IGetKey
{
    private EatScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the eat script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        if (!Game.SelectItem(out Item? item, "Eat which item? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeEatenItemFilter))))
        {
            Game.MsgPrint("You have nothing to eat.");
            return;
        }
        if (item == null)
        {
            return;
        }

        // Make sure the item is edible
        if (item.EatScript == null)
        {
            Game.MsgPrint("You can't eat that!");
            return;
        }

        // Eating costs 100 energy
        Game.EnergyUse = 100;
        int itemLevel = item.LevelNormallyFound;

        // Allow the food item to process the consumption.
        IdentifiedResultEnum eatResult = item.EatScript.ExecuteEatOrQuaffScript();

        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();

        // We've tried this type of object  
        item.ObjectTried();

        // Learn its flavor if necessary
        if (eatResult == IdentifiedResultEnum.True && !item.IsFlavorAware)
        {
            item.IsFlavorAware = true;
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.IntValue >> 1)) / Game.ExperienceLevel.IntValue);
        }

        // Now races process the sustenance.
        Game.Race.Eat(item);

        // Dwarf bread isn't actually eaten so return early
        if (item.IsConsumedWhenEaten)
        {
            // Use up the item (if it fell to the floor this will have already been dealt with)
            IItemContainer container = item.GetContainer();
            item.ModifyStackCount(-1);
            item.ItemOptimize();
            string containerDescription = container.DescribeContainer(item);
            Game.MsgPrint(containerDescription);
        }
    }
}
