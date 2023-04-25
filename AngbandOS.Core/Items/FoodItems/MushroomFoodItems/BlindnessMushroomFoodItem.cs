namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlindnessMushroomFoodItem : MushroomFoodItem
    {
        public BlindnessMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlindnessMushroomFoodItemFactory>()) { }
    }
}