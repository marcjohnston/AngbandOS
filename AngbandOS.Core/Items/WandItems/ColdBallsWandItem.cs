namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ColdBallsWandItem : WandItem
    {
        public ColdBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ColdBallsWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
        }
    }
}