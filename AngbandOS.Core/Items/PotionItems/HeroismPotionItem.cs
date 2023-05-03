namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HeroismPotionItem : PotionItem
    {
        public HeroismPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HeroismPotionItemFactory>()) { }
    }
}