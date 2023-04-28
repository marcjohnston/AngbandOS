namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IceRingItem : RingItem
    {
        public IceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingIce>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        }
        public override string? FactoryDescribeActivationEffect()
        {
            return "ball of cold and resist cold";
        }
    }
}