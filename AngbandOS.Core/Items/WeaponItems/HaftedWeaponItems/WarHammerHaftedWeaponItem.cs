namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WarHammerHaftedWeaponItem : HaftedWeaponItem
    {
        public WarHammerHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HaftedWarHammer>()) { }
    }
}