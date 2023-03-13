namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OfOilFlaskItem : FlaskItem
    {
        public OfOilFlaskItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FlaskOfOil>()) { }
    }
}