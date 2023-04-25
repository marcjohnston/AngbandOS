namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Garnets1GoldItem : GoldItem
    {
        public Garnets1GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldGarnets1>()) { }
    }
}