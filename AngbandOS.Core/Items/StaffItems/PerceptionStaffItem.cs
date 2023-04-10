namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PerceptionStaffItem : StaffItem
    {
        public PerceptionStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffPerception>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 5;
        }
    }
}