namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DamageRingItem : RingItem
    {
        public DamageRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DamageRingItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            BonusDamage = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                BonusDamage = 0 - BonusDamage;
            }
        }
    }
}