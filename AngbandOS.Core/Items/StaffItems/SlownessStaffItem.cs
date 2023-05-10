namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlownessStaffItem : StaffItem
    {
        public SlownessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffSlowness>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
        }
    }
}