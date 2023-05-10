namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DoomAmuletJeweleryItem : AmuletJeweleryItem
    {
        public DoomAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DoomAmuletJeweleryItemFactory>()) { }

        protected override void ApplyMagic(int level, int power, Store? store)
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
            BonusArmourClass = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
        }
    }
}