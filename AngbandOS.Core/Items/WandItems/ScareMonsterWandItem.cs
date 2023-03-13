namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ScareMonsterWandItem : WandItem
    {
        public ScareMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandScareMonster>()) { }
    }
}