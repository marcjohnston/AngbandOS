namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapLocationRodItem : RodItem
    {
        public TrapLocationRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodTrapLocation>()) { }
    }
}