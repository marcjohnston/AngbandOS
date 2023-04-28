namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShardBallsWandItem : WandItem
    {
        public ShardBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ShardBallsWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}