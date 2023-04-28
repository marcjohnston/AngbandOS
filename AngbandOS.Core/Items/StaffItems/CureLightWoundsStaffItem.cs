namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureLightWoundsStaffItem : StaffItem
    {
        public CureLightWoundsStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffCureLightWounds>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}