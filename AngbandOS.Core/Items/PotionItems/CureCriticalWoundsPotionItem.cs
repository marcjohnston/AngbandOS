namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureCriticalWoundsPotionItem : PotionItem
    {
        public CureCriticalWoundsPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionCureCriticalWounds>()) { }
    }
}