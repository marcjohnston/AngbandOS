namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ParanoiaMushroomItem : MushroomItem
    {
        public ParanoiaMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomParanoia>()) { }
    }
}