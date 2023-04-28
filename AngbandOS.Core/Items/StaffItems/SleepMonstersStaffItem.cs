namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SleepMonstersStaffItem : StaffItem
    {
        public SleepMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffSleepMonsters>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}