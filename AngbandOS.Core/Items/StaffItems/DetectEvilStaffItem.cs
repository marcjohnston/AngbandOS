namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectEvilStaffItem : StaffItem
    {
        public DetectEvilStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffDetectEvil>()) { }
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        }
    }
}