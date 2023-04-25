namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreConstitutionMushroomFoodItem : MushroomFoodItem
    {
        public RestoreConstitutionMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RestoreConstitutionMushroomFoodItemFactory>()) { }
    }
}