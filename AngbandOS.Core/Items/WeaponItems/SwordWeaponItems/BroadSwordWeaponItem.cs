namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BroadSwordWeaponItem : SwordWeaponItem
    {
        public BroadSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordBroadSword>()) { }
    }
}