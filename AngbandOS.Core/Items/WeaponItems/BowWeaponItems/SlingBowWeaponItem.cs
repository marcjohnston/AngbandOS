namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlingBowWeaponItem : BowWeaponItem
    {
        public SlingBowWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SlingBowWeaponItemFactory>()) { }
    }
}