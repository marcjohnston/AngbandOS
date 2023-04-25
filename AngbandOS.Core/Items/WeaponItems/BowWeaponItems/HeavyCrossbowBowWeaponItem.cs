namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HeavyCrossbowBowWeaponItem : BowWeaponItem
    {
        public HeavyCrossbowBowWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HeavyCrossbowBowWeaponItemFactory>()) { }
    }
}