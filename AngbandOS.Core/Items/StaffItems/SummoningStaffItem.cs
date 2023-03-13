namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SummoningStaffItem : StaffItem
    {
        public SummoningStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSummoning>()) { }
    }
}