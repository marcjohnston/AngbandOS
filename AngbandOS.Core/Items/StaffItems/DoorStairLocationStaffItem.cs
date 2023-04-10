namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DoorStairLocationStaffItem : StaffItem
    {
        public DoorStairLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDoorStairLocation>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}