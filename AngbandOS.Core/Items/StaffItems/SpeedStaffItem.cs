namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpeedStaffItem : StaffItem
    {
        public SpeedStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffSpeed>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
        }
    }
}