namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LongBowWeaponItem : BowWeaponItem
    {
        public LongBowWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LongBowWeaponItemFactory>()) { }
    }
}