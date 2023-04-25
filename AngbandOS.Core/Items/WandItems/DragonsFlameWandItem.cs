namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFlameWandItem : WandItem
    {
        public DragonsFlameWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandDragonsFlame>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}