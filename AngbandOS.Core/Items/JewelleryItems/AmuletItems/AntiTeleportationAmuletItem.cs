namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiTeleportationAmuletItem : AmuletItem
    {
        public AntiTeleportationAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAntiTeleportation>()) { }
    }
}