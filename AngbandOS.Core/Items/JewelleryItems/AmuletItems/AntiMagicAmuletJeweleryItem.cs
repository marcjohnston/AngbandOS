namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiMagicAmuletJeweleryItem : AmuletJeweleryItem
    {
        public AntiMagicAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AntiMagicAmuletJeweleryItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                IdentCursed = true;
            }
        }
    }
}