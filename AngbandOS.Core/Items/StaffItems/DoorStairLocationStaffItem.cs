namespace AngbandOS.Core.Items;

[Serializable]
internal class DoorStairLocationStaffItem : StaffItem
{
    public DoorStairLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffDoorStairLocation>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
    }
}