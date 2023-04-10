namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HealingStaffItem : StaffItem
    {
        public HealingStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffHealing>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}