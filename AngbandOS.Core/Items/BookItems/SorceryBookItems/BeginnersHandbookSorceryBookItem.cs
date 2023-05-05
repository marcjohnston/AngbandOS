namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BeginnersHandbookSorceryBookItem : SorceryBookItem
    {
        public BeginnersHandbookSorceryBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BeginnersHandbookSorceryBookItemFactory>()) { }
    }
}