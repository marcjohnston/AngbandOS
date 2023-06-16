namespace AngbandOS.Core.Items;

[Serializable]
internal class HolinessStaffItem : StaffItem
{
    public HolinessStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffHoliness>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
    }
}