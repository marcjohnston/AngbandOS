namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpeedRingItem : RingItem
    {
        public SpeedRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSpeed>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            while (Program.Rng.RandomLessThan(100) < 50)
            {
                TypeSpecificValue++;
            }
            if (power < 0)
            {
                IdentBroken = true;
                IdentCursed = true;
                TypeSpecificValue = 0 - TypeSpecificValue;
            }
            else if (SaveGame.Level != null)
            {
                SaveGame.Level.TreasureRating += 25;
            }
        }
    }
}