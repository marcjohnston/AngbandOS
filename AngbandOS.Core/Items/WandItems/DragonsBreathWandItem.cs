namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsBreathWandItem : WandItem
    {
        public DragonsBreathWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DragonsBreathWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}