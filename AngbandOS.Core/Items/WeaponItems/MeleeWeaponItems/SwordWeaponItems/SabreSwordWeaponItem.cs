namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SabreSwordWeaponItem : SwordWeaponItem
    {
        public SabreSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordSabre>()) { }
    }
}