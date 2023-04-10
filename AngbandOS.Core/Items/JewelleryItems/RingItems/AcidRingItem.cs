namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidRingItem : RingItem
    {
        public AcidRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingAcid>()) { }
        public override void ApplyMagic(int level, int power)
        {
            BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        }
        public override string? FactoryDescribeActivationEffect()
        {
            return "ball of acid and resist acid";
        }
    }
}