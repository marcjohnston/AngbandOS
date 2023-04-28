namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationStaffItem : StaffItem
    {
        public TeleportationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffTeleportation>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(4) + 5;
        }
    }
}