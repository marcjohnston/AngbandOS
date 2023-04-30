namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidRingItem : RingItem
    {
        public AcidRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AcidRingItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        }
    }
}