namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiMagicAmuletItem : AmuletItem
    {
        public AntiMagicAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAntiMagic>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                IdentCursed = true;
            }
        }
    }
}