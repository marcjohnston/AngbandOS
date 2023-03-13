namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConfuseMonsterWandItem : WandItem
    {
        public ConfuseMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandConfuseMonster>()) { }
    }
}