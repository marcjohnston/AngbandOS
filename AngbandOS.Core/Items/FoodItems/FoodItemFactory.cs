namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FoodItemFactory : ItemFactory
    {
        public FoodItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Food;
        public override int PackSort => 9;
        public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        public override Colour Colour => Colour.Green;
        public virtual bool VanishesWhenEatenBySkeletons => false;

        /// <summary>
        /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
        /// all food items except for dwarf bread.  Dwarf bread returns false.
        /// </summary>
        public virtual bool IsConsumedWhenEaten => true;

        public abstract bool Eat();
    }
}
