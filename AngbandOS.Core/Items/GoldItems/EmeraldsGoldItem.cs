namespace AngbandOS.Core.Items;

[Serializable]
internal class EmeraldsGoldItem : GoldItem
{
    public EmeraldsGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldEmeralds>()) { }
}