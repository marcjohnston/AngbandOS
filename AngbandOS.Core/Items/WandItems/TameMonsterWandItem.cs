namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TameMonsterWandItem : WandItem
    {
        public TameMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandTameMonster>()) { }
    }
}