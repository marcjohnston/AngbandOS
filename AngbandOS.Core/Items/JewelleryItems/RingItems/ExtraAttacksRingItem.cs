namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ExtraAttacksRingItem : RingItem
    {
        public ExtraAttacksRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingExtraAttacks>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            TypeSpecificValue = GetBonusValue(3, level);
            if (TypeSpecificValue < 1)
            {
                TypeSpecificValue = 1;
            }
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                TypeSpecificValue = 0 - TypeSpecificValue;
            }
        }
    }
}