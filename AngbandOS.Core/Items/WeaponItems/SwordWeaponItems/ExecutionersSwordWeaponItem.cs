namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ExecutionersSwordWeaponItem : SwordWeaponItem
    {
        public ExecutionersSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SwordExecutionersSword>()) { }
    }
}