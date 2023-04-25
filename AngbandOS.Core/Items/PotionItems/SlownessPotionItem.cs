namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlownessPotionItem : PotionItem
    {
        public SlownessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PotionSlowness>()) { }
    }
}