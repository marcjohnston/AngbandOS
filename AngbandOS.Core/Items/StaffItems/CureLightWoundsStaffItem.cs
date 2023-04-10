namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureLightWoundsStaffItem : StaffItem
    {
        public CureLightWoundsStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffCureLightWounds>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}