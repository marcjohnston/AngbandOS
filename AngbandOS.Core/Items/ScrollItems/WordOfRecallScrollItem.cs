namespace AngbandOS.Core.Items;

[Serializable]
internal class WordOfRecallScrollItem : ScrollItem
{
    public WordOfRecallScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollWordOfRecall>()) { }
}