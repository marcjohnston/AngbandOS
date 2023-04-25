namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FlamesRingItem : RingItem
    {
        public FlamesRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingFlames>()) { }
        public override void ApplyMagic(int level, int power)
        {
            BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        }
        public override string? FactoryDescribeActivationEffect()
        {
            return "ball of fire and resist fire";
        }
    }
}