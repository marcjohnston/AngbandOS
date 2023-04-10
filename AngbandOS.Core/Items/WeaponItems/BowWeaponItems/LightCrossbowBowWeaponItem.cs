namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightCrossbowBowWeaponItem : BowWeaponItem
    {
        public LightCrossbowBowWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightCrossbowBowWeaponItemFactory>()) { }
    }
}