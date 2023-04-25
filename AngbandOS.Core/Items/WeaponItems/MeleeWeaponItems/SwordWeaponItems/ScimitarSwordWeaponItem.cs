namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ScimitarSwordWeaponItem : SwordWeaponItem
    {
        public ScimitarSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordScimitar>()) { }
    }
}