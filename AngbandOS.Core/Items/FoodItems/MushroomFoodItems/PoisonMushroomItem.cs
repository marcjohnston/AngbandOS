namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PoisonMushroomItem : MushroomItem
    {
        public PoisonMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomPoison>()) { }
    }
}