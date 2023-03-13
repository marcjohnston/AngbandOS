namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RobeSoftArmorItem : SoftArmorItem
    {
        public RobeSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SoftArmorRobe>()) { }
    }
}