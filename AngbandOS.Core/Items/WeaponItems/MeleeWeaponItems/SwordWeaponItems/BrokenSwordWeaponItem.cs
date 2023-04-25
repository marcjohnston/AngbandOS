namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrokenSwordWeaponItem : SwordWeaponItem
    {
        public BrokenSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordBrokenSword>()) { }
    }
}