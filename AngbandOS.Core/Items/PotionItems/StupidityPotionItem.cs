namespace AngbandOS.Core.Items;

[Serializable]
internal class StupidityPotionItem : PotionItem
{
    public StupidityPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StupidityPotionItemFactory>()) { }
}