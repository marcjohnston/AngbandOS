namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IronShotAmmunitionItem : ShotAmmunitionItem
    {
        public IronShotAmmunitionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<IronShotAmmunitionItemFactory>()) { }
    }
}