namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SteelHelmArmorItem : HelmArmorItem
    {
        public SteelHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HelmSteelHelm>()) { }
    }
}