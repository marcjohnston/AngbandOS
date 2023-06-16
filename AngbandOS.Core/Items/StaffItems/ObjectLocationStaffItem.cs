namespace AngbandOS.Core.Items;

[Serializable]
internal class ObjectLocationStaffItem : StaffItem
{
    public ObjectLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffObjectLocation>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(15) + 6;
    }
}