namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShortSwordWeaponItem : SwordWeaponItem
    {
        public ShortSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordShortSword>()) { }
    }
}