namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightWandItem : WandItem
    {
        public LightWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandLight>()) { }
    }
}