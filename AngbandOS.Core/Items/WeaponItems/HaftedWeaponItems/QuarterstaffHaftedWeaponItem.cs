namespace AngbandOS.Core.Items
{
[Serializable]
    internal class QuarterstaffHaftedWeaponItem : HaftedWeaponItem
    {
        public QuarterstaffHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HaftedQuarterstaff>()) { }
    }
}