namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HasteMonsterWandItem : WandItem
    {
        public HasteMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandHasteMonster>()) { }
    }
}