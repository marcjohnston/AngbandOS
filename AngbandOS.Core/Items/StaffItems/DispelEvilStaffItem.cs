namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DispelEvilStaffItem : StaffItem
    {
        public DispelEvilStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDispelEvil>()) { }
    }
}