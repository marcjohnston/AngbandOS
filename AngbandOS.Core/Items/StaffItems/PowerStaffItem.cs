namespace AngbandOS.Core.Items;

[Serializable]
internal class PowerStaffItem : StaffItem
{
    public PowerStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffPower>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
    }
}