namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IronHelmArmorItem : HelmArmorItem
    {
        public IronHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HelmIronHelm>()) { }
    }
}