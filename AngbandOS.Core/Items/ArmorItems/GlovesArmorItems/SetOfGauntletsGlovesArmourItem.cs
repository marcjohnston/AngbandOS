namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfGauntletsGlovesArmourItem : FoodItem
    {
        public SetOfGauntletsGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfGauntlets>()) { }
    }
}