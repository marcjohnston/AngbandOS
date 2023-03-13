namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CuringRodItem : RodItem
    {
        public CuringRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodCuring>()) { }
    }
}