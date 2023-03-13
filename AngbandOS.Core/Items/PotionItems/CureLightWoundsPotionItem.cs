namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureLightWoundsPotionItem : PotionItem
    {
        public CureLightWoundsPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionCureLightWounds>()) { }
    }
}