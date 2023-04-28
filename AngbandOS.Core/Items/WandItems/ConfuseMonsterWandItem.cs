namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConfuseMonsterWandItem : WandItem
    {
        public ConfuseMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ConfuseMonsterWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(12) + 6;
        }
    }
}