namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportOtherWandItem : WandItem
    {
        public TeleportOtherWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandTeleportOther>()) { }
    }
}