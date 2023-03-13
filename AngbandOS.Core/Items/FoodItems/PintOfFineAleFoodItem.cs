namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PintOfFineAleFoodItem : FoodItem
    {
        public PintOfFineAleFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FoodPintOfFineAle>()) { }
    }
}