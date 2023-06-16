namespace AngbandOS.Core.Items;

[Serializable]
internal class WhipHaftedWeaponItem : HaftedWeaponItem
{
    public WhipHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HaftedWhip>()) { }
}