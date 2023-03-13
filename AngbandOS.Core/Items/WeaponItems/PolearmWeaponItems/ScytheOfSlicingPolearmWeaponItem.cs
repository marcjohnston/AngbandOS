namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ScytheOfSlicingPolearmWeaponItem : PolearmWeaponItem
    {
        public ScytheOfSlicingPolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmScytheOfSlicing>()) { }
    }
}