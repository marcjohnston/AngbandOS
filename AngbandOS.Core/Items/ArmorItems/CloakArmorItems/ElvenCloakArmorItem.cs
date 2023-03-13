namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ElvenCloakArmorItem : CloakArmorItem
    {
        public ElvenCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CloakElven>()) { }
    }
}