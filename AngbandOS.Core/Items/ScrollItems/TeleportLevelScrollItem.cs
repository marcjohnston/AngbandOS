namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportLevelScrollItem : ScrollItem
    {
        public TeleportLevelScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollTeleportLevel>()) { }
    }
}