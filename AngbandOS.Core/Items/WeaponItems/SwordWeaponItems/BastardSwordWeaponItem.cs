namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BastardSwordWeaponItem : SwordWeaponItem
    {
        public BastardSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordBastardSword>()) { }
    }
}