namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrokenDaggerSwordWeaponItem : SwordWeaponItem
    {
        public BrokenDaggerSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordBrokenDagger>()) { }
    }
}