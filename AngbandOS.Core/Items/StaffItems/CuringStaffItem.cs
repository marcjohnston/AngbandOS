namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CuringStaffItem : StaffItem
    {
        public CuringStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffCuring>()) { }
    }
}