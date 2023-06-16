namespace AngbandOS.Core.Items;

[Serializable]
internal class IdentifyScrollItem : ScrollItem
{
    public IdentifyScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollIdentify>()) { }
}