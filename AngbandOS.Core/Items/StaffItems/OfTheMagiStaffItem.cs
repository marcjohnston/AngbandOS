namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OfTheMagiStaffItem : StaffItem
    {
        public OfTheMagiStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffOfTheMagi>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
        }
    }
}