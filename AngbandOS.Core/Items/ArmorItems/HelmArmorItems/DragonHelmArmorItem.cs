namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonHelmArmorItem : HelmArmorItem
    {
        public DragonHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HelmDragonHelm>()) { }
    }
}