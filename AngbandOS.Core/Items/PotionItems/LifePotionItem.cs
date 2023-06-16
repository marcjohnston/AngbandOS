namespace AngbandOS.Core.Items;

[Serializable]
internal class LifePotionItem : PotionItem
{
    public LifePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LifePotionItemFactory>()) { }
}