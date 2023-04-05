namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BroadAxePolearmWeaponItem : PolearmWeaponItem
    {
        public BroadAxePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmBroadAxe>()) { }
    }
}