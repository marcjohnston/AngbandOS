namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SleepMonsterRodItem : RodItem
    {
        public SleepMonsterRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodSleepMonster>()) { }
    }
}