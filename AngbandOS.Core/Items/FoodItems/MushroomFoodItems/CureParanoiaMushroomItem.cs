namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureParanoiaMushroomItem : MushroomItem
    {
        public CureParanoiaMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomCureParanoia>()) { }
    }
}