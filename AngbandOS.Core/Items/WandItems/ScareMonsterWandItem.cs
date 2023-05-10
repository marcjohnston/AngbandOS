namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ScareMonsterWandItem : WandItem
    {
        public ScareMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScareMonsterWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        }
    }
}