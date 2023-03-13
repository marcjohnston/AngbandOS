namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShortBowWeaponItem : BowWeaponItem
    {
        public ShortBowWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<BowShort>()) { }
    }
}