namespace AngbandOS.Core.Items;

[Serializable]
internal class TreasureLocationStaffItem : StaffItem
{
    public TreasureLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffTreasureLocation>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
    }
}