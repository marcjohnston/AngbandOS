namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HeavyCrossbowBowWeapon : BowWeaponItem
    {
        public HeavyCrossbowBowWeapon(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<BowHeavyCrossbow>()) { }
    }
}