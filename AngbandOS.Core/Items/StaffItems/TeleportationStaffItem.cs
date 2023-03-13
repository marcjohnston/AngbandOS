namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationStaffItem : StaffItem
    {
        public TeleportationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffTeleportation>()) { }
    }
}