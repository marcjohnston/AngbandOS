namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CarnageStaffItem : StaffItem
    {
        public CarnageStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffCarnage>()) { }
    }
}