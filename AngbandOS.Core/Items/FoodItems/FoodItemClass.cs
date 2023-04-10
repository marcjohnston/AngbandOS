namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FoodItemClass : ItemFactory
    {
        public FoodItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Food;
        public override int PackSort => 9;
        public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        public override Colour Colour => Colour.Green;


        public abstract bool Eat(SaveGame saveGame);
    }
}
