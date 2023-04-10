namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SleepMonstersStaffItem : StaffItem
    {
        public SleepMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffSleepMonsters>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}