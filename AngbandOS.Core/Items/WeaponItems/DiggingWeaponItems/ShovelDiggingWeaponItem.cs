namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShovelDiggingWeaponItem : DiggingWeaponItem
    {
        public ShovelDiggingWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DiggingShovel>()) { }
    }
}