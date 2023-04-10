namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlownessStaffItem : StaffItem
    {
        public SlownessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSlowness>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
        }
    }
}