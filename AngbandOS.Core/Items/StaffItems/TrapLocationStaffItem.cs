namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapLocationStaffItem : StaffItem
    {
        public TrapLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffTrapLocation>()) { }
    }
}