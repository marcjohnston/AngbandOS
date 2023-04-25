namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CopperGoldItem : GoldItem
    {
        public CopperGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldCopper>()) { }
    }
}