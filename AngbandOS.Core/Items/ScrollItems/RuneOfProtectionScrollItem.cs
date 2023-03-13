namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RuneOfProtectionScrollItem : ScrollItem
    {
        public RuneOfProtectionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollRuneOfProtection>()) { }
    }
}