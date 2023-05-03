namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SicklinessPotionItem : PotionItem
    {
        public SicklinessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SicklinessPotionItemFactory>()) { }
    }
}