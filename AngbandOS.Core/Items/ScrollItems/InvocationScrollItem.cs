namespace AngbandOS.Core.Items
{
[Serializable]
    internal class InvocationScrollItem : ScrollItem
    {
        public InvocationScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollInvocation>()) { }
    }
}