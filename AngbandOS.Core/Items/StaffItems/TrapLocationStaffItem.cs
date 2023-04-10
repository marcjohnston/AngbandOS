namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapLocationStaffItem : StaffItem
    {
        public TrapLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffTrapLocation>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}