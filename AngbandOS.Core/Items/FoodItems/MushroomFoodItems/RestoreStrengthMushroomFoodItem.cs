namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreStrengthMushroomFoodItem : MushroomFoodItem
    {
        public RestoreStrengthMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RestoreStrengthMushroomFoodItemFactory>()) { }
    }
}