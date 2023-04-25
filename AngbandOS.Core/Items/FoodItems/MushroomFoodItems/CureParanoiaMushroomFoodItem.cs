namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureParanoiaMushroomFoodItem : MushroomFoodItem
    {
        public CureParanoiaMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CureParanoiaMushroomFoodItemFactory>()) { }
    }
}