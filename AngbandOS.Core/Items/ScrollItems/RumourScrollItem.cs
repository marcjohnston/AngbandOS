namespace AngbandOS.Core.Items;

[Serializable]
internal class RumourScrollItem : ScrollItem
{
    public RumourScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollRumour>()) { }
}