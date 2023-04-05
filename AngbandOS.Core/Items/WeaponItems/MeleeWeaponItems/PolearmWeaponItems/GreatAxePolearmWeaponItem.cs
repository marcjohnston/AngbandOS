namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreatAxePolearmWeaponItem : PolearmWeaponItem
    {
        public GreatAxePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmGreatAxe>()) { }
    }
}