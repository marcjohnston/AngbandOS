namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HealMonsterWandItem : WandItem
    {
        public HealMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HealMonsterWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        }
    }
}