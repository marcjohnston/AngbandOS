namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistColdRingItem : RingItem
    {
        public ResistColdRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingResistCold>()) { }
    }
}