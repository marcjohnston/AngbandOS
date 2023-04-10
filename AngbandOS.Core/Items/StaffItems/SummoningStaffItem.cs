namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SummoningStaffItem : StaffItem
    {
        public SummoningStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSummoning>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}