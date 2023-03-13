namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FireBoltsWandItem : WandItem
    {
        public FireBoltsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandFireBolts>()) { }
    }
}