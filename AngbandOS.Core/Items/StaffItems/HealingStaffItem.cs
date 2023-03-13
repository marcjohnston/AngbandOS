namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HealingStaffItem : StaffItem
    {
        public HealingStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffHealing>()) { }
    }
}