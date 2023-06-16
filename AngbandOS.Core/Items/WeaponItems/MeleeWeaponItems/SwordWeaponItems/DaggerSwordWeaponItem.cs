namespace AngbandOS.Core.Items;

[Serializable]
internal class DaggerSwordWeaponItem : SwordWeaponItem
{
    public DaggerSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordDagger>()) { }
}