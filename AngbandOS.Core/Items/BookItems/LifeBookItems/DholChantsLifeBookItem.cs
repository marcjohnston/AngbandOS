namespace AngbandOS.Core.Items;

[Serializable]
internal class DholChantsLifeBookItem : LifeBookItem
{
    public DholChantsLifeBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DholChantsLifeBookItemFactory>()) { }
}