namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureLightWoundsStaffItem : StaffItem
    {
        public CureLightWoundsStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffCureLightWounds>()) { }
    }
}