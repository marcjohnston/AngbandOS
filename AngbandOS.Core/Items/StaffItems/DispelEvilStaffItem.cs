namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DispelEvilStaffItem : StaffItem
    {
        public DispelEvilStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffDispelEvil>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
        }
    }
}