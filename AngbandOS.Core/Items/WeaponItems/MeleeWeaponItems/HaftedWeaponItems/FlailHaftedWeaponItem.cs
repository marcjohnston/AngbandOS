namespace AngbandOS.Core.Items;

[Serializable]
internal class FlailHaftedWeaponItem : HaftedWeaponItem
{
    public FlailHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HaftedFlail>()) { }
}