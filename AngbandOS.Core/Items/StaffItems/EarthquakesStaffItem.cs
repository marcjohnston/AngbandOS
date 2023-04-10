namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EarthquakesStaffItem : StaffItem
    {
        public EarthquakesStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffEarthquakes>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        }
    }
}