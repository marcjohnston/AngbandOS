namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightCrossbowBowWeapon : BowWeaponItem
    {
        public LightCrossbowBowWeapon(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<BowLightCrossbow>()) { }
    }
}