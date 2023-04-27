namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TameMonsterWandItem : WandItem
    {
        public TameMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TameMonsterWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
        }
    }
}