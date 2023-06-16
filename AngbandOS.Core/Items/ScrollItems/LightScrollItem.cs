namespace AngbandOS.Core.Items;

[Serializable]
internal class LightScrollItem : ScrollItem
{
    public LightScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollLight>()) { }
}