namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpeedStaffItem : StaffItem
    {
        public SpeedStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSpeed>()) { }
    }
}