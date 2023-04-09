namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DexterityRingItem : RingItem
    {
        public DexterityRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingDexterity>()) { }
        public override bool Dex => true;
        public override bool HideType => true;
    }
}