namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RemoveCurseStaffItem : StaffItem
    {
        public RemoveCurseStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffRemoveCurse>()) { }
    }
}