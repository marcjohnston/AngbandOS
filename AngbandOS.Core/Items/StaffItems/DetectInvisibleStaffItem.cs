namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectInvisibleStaffItem : StaffItem
    {
        public DetectInvisibleStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffDetectInvisible>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        }
    }
}