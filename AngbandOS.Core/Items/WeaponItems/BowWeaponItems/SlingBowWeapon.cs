namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlingBowWeapon : BowWeaponItem
    {
        public SlingBowWeapon(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<BowSling>()) { }
    }
}