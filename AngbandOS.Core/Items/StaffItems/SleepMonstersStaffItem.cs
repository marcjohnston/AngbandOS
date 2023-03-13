namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SleepMonstersStaffItem : StaffItem
    {
        public SleepMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSleepMonsters>()) { }
    }
}