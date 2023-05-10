namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapDoorDestructionWandItem : WandItem
    {
        public TrapDoorDestructionWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TrapDoorDestructionWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}