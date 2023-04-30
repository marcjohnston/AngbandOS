namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistFireRingItem : RingItem
    {
        public ResistFireRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ResistFireRingItemFactory>()) { }
    }
}