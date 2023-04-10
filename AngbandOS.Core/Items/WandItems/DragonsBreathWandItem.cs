namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsBreathWandItem : WandItem
    {
        public DragonsBreathWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsBreath>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}