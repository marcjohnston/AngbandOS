namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AnnihilationWandItem : WandItem
    {
        public AnnihilationWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AnnihilationWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}