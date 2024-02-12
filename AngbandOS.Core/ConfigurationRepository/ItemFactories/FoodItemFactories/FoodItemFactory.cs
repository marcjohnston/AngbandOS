// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class FoodItemFactory : ItemFactory
{
    public FoodItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(FoodItemClass));
    public override int PercentageBreakageChance => 100;
    public override bool EasyKnow => true;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Food;

    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        int cost = item.Value();
        if (cost <= 5)
        {
            return item.MassRoll(3, 5);
        }
        if (cost <= 20)
        {
            return item.MassRoll(3, 5);
        }
        return 0;
    }

    public override int PackSort => 9;
    public override int BaseValue => 5;
    //public override bool CanBeConsumed => true;
    public override ColorEnum Color => ColorEnum.Green;
    public virtual bool VanishesWhenEatenBySkeletons => false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public virtual bool IsConsumedWhenEaten => true;

    public abstract bool Eat();
    public override bool CanBeEatenByMonsters => true;
    public override bool CanBeEaten => true;
}
