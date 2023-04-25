namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiTheftAmuletItem : AmuletItem
    {
        public AntiTheftAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletAntiTheft>()) { }
    }
}