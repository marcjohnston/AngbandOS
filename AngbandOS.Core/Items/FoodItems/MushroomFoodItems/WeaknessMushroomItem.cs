namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WeaknessMushroomItem : MushroomItem
    {
        public WeaknessMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomWeakness>()) { }
    }
}