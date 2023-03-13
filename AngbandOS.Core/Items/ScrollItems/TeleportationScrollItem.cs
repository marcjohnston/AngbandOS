namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationScrollItem : ScrollItem
    {
        public TeleportationScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollTeleportation>()) { }
    }
}