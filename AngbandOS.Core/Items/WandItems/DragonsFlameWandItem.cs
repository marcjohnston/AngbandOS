namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFlameWandItem : WandItem
    {
        public DragonsFlameWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DragonsFlameWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}