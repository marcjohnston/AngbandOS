namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectInvisibleStaffItem : StaffItem
    {
        public DetectInvisibleStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDetectInvisible>()) { }
    }
}