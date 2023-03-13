namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DestructionStaffItem : StaffItem
    {
        public DestructionStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDestruction>()) { }
    }
}