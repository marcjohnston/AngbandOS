namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SmallSwordWeaponItem : SwordWeaponItem
    {
        public SmallSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordSmallSword>()) { }
    }
}