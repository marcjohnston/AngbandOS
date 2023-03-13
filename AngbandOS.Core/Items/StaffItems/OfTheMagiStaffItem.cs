namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OfTheMagiStaffItem : StaffItem
    {
        public OfTheMagiStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffOfTheMagi>()) { }
    }
}