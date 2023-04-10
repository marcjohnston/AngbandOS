namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectEvilStaffItem : StaffItem
    {
        public DetectEvilStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDetectEvil>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        }
    }
}