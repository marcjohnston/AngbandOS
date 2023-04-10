namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightStaffItem : StaffItem
    {
        public LightStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffLight>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        }
    }
}