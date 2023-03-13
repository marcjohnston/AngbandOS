namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlownessStaffItem : StaffItem
    {
        public SlownessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSlowness>()) { }
    }
}