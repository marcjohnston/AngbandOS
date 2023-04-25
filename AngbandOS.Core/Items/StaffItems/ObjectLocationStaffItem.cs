namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ObjectLocationStaffItem : StaffItem
    {
        public ObjectLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffObjectLocation>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 6;
        }
    }
}