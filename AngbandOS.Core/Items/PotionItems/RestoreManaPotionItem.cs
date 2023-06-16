namespace AngbandOS.Core.Items;

[Serializable]
internal class RestoreManaPotionItem : PotionItem
{
    public RestoreManaPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RestoreManaPotionItemFactory>()) { }
}