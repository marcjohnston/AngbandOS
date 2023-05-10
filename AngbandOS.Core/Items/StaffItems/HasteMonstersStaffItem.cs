namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HasteMonstersStaffItem : StaffItem
    {
        public HasteMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffHasteMonsters>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
        }
    }
}