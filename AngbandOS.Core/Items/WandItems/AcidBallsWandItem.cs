namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidBallsWandItem : WandItem
    {
        public AcidBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AcidBallsWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 2;
        }
    }
}