namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HasteMonstersStaffItem : StaffItem
    {
        public HasteMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffHasteMonsters>()) { }
    }
}