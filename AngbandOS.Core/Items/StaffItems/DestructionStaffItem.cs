namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DestructionStaffItem : StaffItem
    {
        public DestructionStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffDestruction>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}