namespace AngbandOS.Core.Items;

[Serializable]
internal class RapierSwordWeaponItem : SwordWeaponItem
{
    public RapierSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordRapier>()) { }
}