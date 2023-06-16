namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoeRingItem : RingItem
    {
        public WoeRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WoeRingItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            IdentBroken = true;
            IdentCursed = true;
            BonusArmorClass = 0 - (5 + GetBonusValue(10, level));
            TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
        }
    }
}