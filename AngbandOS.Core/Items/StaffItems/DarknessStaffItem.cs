namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DarknessStaffItem : StaffItem
    {
        public DarknessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffDarkness>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
        }
    }
}