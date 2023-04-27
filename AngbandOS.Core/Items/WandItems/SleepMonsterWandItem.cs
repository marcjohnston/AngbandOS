namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SleepMonsterWandItem : WandItem
    {
        public SleepMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SleepMonsterWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        }
    }
}