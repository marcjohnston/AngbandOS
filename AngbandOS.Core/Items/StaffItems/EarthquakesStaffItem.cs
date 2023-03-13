namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EarthquakesStaffItem : StaffItem
    {
        public EarthquakesStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffEarthquakes>()) { }
    }
}