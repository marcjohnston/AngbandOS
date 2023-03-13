namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SeeInvisibleRingItem : RingItem
    {
        public SeeInvisibleRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSeeInvisible>()) { }
    }
}