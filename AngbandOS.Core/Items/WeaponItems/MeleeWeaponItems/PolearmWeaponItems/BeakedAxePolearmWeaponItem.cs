namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BeakedAxePolearmWeaponItem : PolearmWeaponItem
    {
        public BeakedAxePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmBeakedAxe>()) { }
    }
}