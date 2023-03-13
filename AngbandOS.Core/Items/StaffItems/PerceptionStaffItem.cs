namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PerceptionStaffItem : StaffItem
    {
        public PerceptionStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffPerception>()) { }
    }
}