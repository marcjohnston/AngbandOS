namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CeleanoFragmentTarotBookItem : TarotBookItem
    {
        public CeleanoFragmentTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookCeleanoFragments>()) { }
    }
}