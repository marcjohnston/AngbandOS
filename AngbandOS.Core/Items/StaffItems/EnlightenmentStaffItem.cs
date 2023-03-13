namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EnlightenmentStaffItem : StaffItem
    {
        public EnlightenmentStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffEnlightenment>()) { }
    }
}