namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PickDiggingWeaponItem : DiggingWeaponItem
    {
        public PickDiggingWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DiggingPick>()) { }
    }
}