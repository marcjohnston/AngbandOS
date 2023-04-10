namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RoundedPebbleShotAmmunitionItem : ShotAmmunitionItem
    {
        public RoundedPebbleShotAmmunitionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RoundedPebbleShotAmmunitionItemFactory>()) { }
    }
}