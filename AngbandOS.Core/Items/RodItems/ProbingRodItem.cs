namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ProbingRodItem : RodItem
    {
        public ProbingRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodProbing>()) { }
    }
}