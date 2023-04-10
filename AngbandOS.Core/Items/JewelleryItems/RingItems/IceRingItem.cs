namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IceRingItem : RingItem
    {
        public IceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingIce>()) { }
        public override void ApplyMagic(int level, int power)
        {
            BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        }
    }
}