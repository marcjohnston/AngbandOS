namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HighMassLifeBookItem : LifeBookItem
    {
        public HighMassLifeBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LifeBookHighMass>()) { }
    }
}