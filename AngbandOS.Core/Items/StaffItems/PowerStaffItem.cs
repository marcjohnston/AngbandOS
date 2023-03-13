namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerStaffItem : StaffItem
    {
        public PowerStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffPower>()) { }
    }
}