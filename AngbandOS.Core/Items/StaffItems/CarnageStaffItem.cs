namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CarnageStaffItem : StaffItem
    {
        public CarnageStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffCarnage>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}