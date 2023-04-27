namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SearchingAmuletJeweleryItem : AmuletJeweleryItem
    {
        public SearchingAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SearchingAmuletJeweleryItemFactory>()) { }

        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                IdentBroken = true;
                IdentCursed = true;
                TypeSpecificValue = 0 - TypeSpecificValue;
            }
        }
    }
}