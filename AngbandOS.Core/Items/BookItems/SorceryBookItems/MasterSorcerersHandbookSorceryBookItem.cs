namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MasterSorcerersHandbookSorceryBookItem : SorceryBookItem
    {
        public MasterSorcerersHandbookSorceryBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SorceryBookMasterSorcerersHandbook>()) { }
    }
}