namespace AngbandOS.Core.Items
{
[Serializable]
    internal class KatanaSwordWeaponItem : SwordWeaponItem
    {
        public KatanaSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordKatana>()) { }
    }
}