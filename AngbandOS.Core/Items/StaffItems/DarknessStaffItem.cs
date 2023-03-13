namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DarknessStaffItem : StaffItem
    {
        public DarknessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDarkness>()) { }
    }
}