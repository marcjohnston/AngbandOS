namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightStaffItem : StaffItem
    {
        public LightStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffLight>()) { }
    }
}