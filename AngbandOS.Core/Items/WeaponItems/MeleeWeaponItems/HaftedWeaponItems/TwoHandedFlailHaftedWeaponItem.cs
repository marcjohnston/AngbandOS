namespace AngbandOS.Core.Items;

[Serializable]
internal class TwoHandedFlailHaftedWeaponItem : HaftedWeaponItem
{
    public TwoHandedFlailHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HaftedTwoHandedFlail>()) { }
}