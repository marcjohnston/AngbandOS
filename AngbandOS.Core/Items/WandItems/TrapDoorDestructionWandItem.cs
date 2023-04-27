namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapDoorDestructionWandItem : WandItem
    {
        public TrapDoorDestructionWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TrapDoorDestructionWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}