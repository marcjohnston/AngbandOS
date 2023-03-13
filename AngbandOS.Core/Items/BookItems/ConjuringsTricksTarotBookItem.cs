namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConjuringsTricksTarotBookItem : TarotBookItem
    {
        public ConjuringsTricksTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookConjuringsTricks>()) { }
    }
}