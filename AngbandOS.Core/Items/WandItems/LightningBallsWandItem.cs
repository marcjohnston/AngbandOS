namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightningBallsWandItem : WandItem
    {
        public LightningBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LightningBallsWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 4;
        }
    }
}