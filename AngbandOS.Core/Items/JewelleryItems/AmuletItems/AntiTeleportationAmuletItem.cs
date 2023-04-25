namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiTeleportationAmuletItem : AmuletItem
    {
        public AntiTeleportationAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletAntiTeleportation>()) { }
        public override void ApplyMagic(int level, int power)
        {
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                IdentCursed = true;
            }
        }
    }
}