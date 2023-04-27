namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CharismaAmuletJeweleryItem : AmuletJeweleryItem
    {
        public CharismaAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CharismaAmuletJeweleryItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
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