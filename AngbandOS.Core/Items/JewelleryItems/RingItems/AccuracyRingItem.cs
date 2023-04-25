namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AccuracyRingItem : RingItem
    {
        public AccuracyRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingAccuracy>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            BonusToHit = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                BonusToHit = 0 - BonusToHit;
            }
        }
    }
}