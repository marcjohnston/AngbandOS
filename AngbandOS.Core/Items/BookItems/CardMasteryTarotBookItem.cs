namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CardMasteryTarotBookItem : TarotBookItem
    {
        public CardMasteryTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookCardMastery>()) { }
    }
}