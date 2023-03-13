namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ProbingStaffItem : StaffItem
    {
        public ProbingStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffProbing>()) { }
    }
}