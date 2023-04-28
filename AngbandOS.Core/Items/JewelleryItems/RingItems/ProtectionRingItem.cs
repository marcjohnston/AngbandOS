namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ProtectionRingItem : RingItem
    {
        public ProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingProtection>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            BonusArmourClass = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                BonusArmourClass = 0 - BonusArmourClass;
            }
        }
    }
}