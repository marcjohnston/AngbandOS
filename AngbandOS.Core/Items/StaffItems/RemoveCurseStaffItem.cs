namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RemoveCurseStaffItem : StaffItem
    {
        public RemoveCurseStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffRemoveCurse>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
        }
    }
}