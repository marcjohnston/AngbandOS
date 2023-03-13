namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MagicMissileWandItem : WandItem
    {
        public MagicMissileWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandMagicMissile>()) { }
    }
}