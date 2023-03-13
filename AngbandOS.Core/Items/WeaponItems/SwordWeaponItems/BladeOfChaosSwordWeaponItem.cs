namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BladeOfChaosSwordWeaponItem : SwordWeaponItem
    {
        public BladeOfChaosSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordBladeOfChaos>()) { }
    }
}