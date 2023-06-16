namespace AngbandOS.Core.Items;

[Serializable]
internal class YogicMasteryCorporealBookItem : CorporealBookItem
{
    public YogicMasteryCorporealBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<YogicMasteryCorporealBookItemFactory>()) { }
}