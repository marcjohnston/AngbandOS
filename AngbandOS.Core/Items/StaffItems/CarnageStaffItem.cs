namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CarnageStaffItem : StaffItem
    {
        public CarnageStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffCarnage>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}