namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationAmuletItem : AmuletItem
    {
        public TeleportationAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletTeleportation>()) { }
    }
}