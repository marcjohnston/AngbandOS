namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainCharismaRingItem : RingItem
    {
        public SustainCharismaRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingSustainCharisma>()) { }
    }
}