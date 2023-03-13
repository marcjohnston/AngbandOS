namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HolinessStaffItem : StaffItem
    {
        public HolinessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffHoliness>()) { }
    }
}