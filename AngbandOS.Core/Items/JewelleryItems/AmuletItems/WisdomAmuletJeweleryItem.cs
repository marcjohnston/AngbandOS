namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WisdomAmuletJeweleryItem : AmuletJeweleryItem
    {
        public WisdomAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WisdomAmuletJeweleryItemFactory>()) { }

        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = 1 + GetBonusValue(5, level);
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                IdentBroken = true;
                IdentCursed = true;
                TypeSpecificValue = 0 - TypeSpecificValue;
            }
        }
    }
}