namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CloneMonsterWandItem : WandItem
    {
        public CloneMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandCloneMonster>()) { }
    }
}