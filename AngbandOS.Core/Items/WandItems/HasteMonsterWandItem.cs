namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HasteMonsterWandItem : WandItem
    {
        public HasteMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HasteMonsterWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        }
    }
}