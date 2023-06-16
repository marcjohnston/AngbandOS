namespace AngbandOS.Core.Items;

[Serializable]
internal class CuringStaffItem : StaffItem
{
    public CuringStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffCuring>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
    }
}