namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfCestiGlovesArmourItem : FoodItem
    {
        public SetOfCestiGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfCesti>()) { }
    }
}