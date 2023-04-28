namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowMonstersStaffItem : StaffItem
    {
        public SlowMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffSlowMonsters>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}