namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TreasureLocationStaffItem : StaffItem
    {
        public TreasureLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffTreasureLocation>()) { }
    }
}