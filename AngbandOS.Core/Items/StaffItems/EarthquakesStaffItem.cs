namespace AngbandOS.Core.Items;

[Serializable]
internal class EarthquakesStaffItem : StaffItem
{
    public EarthquakesStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffEarthquakes>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
    }
}