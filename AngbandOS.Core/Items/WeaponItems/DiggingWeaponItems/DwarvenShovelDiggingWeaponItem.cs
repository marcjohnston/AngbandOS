namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DwarvenShovelDiggingWeaponItem : DiggingWeaponItem
    {
        public DwarvenShovelDiggingWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DiggingDwarvenShovel>()) { }
    }
}