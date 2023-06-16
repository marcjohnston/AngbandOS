namespace AngbandOS.Core.Items;

[Serializable]
internal class GoldGoldItem : GoldItem
{
    public GoldGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldGold>()) { }
}