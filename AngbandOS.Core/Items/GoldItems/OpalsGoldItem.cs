namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OpalsGoldItem : GoldItem
    {
        public OpalsGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldOpals>()) { }
    }
}