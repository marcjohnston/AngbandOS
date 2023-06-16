namespace AngbandOS.Core.Items;

[Serializable]
internal class TrapLocationStaffItem : StaffItem
{
    public TrapLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffTrapLocation>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
    }
}