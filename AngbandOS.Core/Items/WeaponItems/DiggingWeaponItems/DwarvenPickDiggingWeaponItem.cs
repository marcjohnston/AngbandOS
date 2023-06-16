namespace AngbandOS.Core.Items;

[Serializable]
internal class DwarvenPickDiggingWeaponItem : DiggingWeaponItem
{
    public DwarvenPickDiggingWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DiggingDwarvenPick>()) { }
}