namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightStaffItem : StaffItem
    {
        public LightStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffLight>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        }
    }
}