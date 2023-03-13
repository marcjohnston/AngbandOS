namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StarlightStaffItem : StaffItem
    {
        public StarlightStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffStarlight>()) { }
    }
}