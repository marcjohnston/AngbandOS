namespace AngbandOS.Core.Items;

[Serializable]
internal class BrokenStickJunkItem : JunkItem
{
    public BrokenStickJunkItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<JunkBrokenStick>()) { }
}