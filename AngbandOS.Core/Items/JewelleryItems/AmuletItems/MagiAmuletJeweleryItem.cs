namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MagiAmuletJeweleryItem : AmuletJeweleryItem
    {
        public MagiAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MagiAmuletJeweleryItemFactory>()) { }

        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            BonusArmourClass = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            if (Program.Rng.DieRoll(3) == 1)
            {
                RandartItemCharacteristics.SlowDigest = true;
            }
            if (SaveGame.Level != null)
            {
                SaveGame.Level.TreasureRating += 25;
            }
        }
    }
}