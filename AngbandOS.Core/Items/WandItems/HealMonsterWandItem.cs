namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HealMonsterWandItem : WandItem
    {
        public HealMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandHealMonster>()) { }
    }
}