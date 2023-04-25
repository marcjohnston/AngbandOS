namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StrengthRingItem : RingItem
    {
        public StrengthRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingStrength>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            TypeSpecificValue = 1 + GetBonusValue(5, level);
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                TypeSpecificValue = 0 - TypeSpecificValue;
            }
        }
    }
}