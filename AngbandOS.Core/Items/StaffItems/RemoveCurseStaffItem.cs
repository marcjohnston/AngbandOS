namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RemoveCurseStaffItem : StaffItem
    {
        public RemoveCurseStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffRemoveCurse>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
        }
    }
}