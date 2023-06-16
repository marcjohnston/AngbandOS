namespace AngbandOS.Core.Items;

[Serializable]
internal class CureSeriousWoundsPotionItem : PotionItem
{
    public CureSeriousWoundsPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CureSeriousWoundsPotionItemFactory>()) { }
}