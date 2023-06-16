namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FlamesRingItem : RingItem
    {
        public FlamesRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<FlamesRingItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            BonusArmorClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        }
    }
}