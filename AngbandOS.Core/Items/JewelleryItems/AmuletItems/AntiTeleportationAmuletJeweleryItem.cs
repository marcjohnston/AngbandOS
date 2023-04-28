namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiTeleportationAmuletJeweleryItem : AmuletJeweleryItem
    {
        public AntiTeleportationAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AntiTeleportationAmuletJeweleryItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                IdentCursed = true;
            }
        }
    }
}