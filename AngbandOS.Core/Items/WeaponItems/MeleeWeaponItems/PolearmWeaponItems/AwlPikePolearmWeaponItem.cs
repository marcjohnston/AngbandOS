namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AwlPikePolearmWeaponItem : PolearmWeaponItem
    {
        public AwlPikePolearmWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PolearmAwlPike>()) { }
    }
}