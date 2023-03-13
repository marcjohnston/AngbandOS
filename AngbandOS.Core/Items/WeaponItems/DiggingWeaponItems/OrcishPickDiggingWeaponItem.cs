namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OrcishPickDiggingWeaponItem : DiggingWeaponItem
    {
        public OrcishPickDiggingWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DiggingOrcishPick>()) { }
    }
}