namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HasteMonstersStaffItem : StaffItem
    {
        public HasteMonstersStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffHasteMonsters>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
        }
    }
}