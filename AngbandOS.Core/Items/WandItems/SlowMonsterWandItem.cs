namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowMonsterWandItem : WandItem
    {
        public SlowMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandSlowMonster>()) { }
    }
}