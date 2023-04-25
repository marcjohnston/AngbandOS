namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainDexterityRingItem : RingItem
    {
        public SustainDexterityRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingSustainDexterity>()) { }
    }
}