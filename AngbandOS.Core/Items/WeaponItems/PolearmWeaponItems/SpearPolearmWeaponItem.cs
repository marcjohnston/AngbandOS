namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpearPolearmWeaponItem : PolearmWeaponItem
    {
        public SpearPolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmSpear>()) { }
    }
}