namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TameMonsterWandItem : WandItem
    {
        public TameMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TameMonsterWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
        }
    }
}