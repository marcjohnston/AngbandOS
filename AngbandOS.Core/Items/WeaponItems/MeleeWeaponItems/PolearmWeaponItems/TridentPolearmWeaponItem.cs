namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TridentPolearmWeaponItem : PolearmWeaponItem
    {
        public TridentPolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmTrident>()) { }
    }
}