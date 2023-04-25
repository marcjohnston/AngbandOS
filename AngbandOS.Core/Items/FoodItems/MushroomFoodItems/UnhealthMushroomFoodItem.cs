namespace AngbandOS.Core.Items
{
[Serializable]
    internal class UnhealthMushroomFoodItem : MushroomFoodItem
    {
        public UnhealthMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<UnhealthMushroomFoodItemFactory>()) { }
    }
}