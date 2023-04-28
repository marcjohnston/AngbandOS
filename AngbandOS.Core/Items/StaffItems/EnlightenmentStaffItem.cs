namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EnlightenmentStaffItem : StaffItem
    {
        public EnlightenmentStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffEnlightenment>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 5;
        }
    }
}