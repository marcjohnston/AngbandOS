namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SleepMonsterWandItem : WandItem
    {
        public SleepMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandSleepMonster>()) { }
    }
}