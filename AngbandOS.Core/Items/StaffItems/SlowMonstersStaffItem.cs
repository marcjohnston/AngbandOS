namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowMonstersStaffItem : StaffItem
    {
        public SlowMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSlowMonsters>()) { }
    }
}