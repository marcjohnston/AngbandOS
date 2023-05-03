namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RuinationPotionItem : PotionItem
    {
        public RuinationPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RuinationPotionItemFactory>()) { }
    }
}