namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectEvilStaffItem : StaffItem
    {
        public DetectEvilStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDetectEvil>()) { }
    }
}