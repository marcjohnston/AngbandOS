namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PoisonMushroomFoodItem : MushroomFoodItem
    {
        public PoisonMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PoisonMushroomFoodItemFactory>()) { }
    }
}