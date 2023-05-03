namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IntelligencePotionItem : PotionItem
    {
        public IntelligencePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<IntelligencePotionItemFactory>()) { }
    }
}