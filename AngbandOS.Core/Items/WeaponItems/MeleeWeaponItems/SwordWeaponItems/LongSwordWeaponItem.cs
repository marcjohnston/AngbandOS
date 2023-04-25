namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LongSwordWeaponItem : SwordWeaponItem
    {
        public LongSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordLongSword>()) { }
    }
}