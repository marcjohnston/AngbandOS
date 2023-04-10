namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlayingRingItem : RingItem
    {
        public SlayingRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSlaying>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            BonusDamage = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
            BonusToHit = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                BonusToHit = 0 - BonusToHit;
                BonusDamage = 0 - BonusDamage;
            }
        }
    }
}