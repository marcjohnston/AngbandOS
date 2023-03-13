namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CloakCloakArmorItem : CloakArmorItem
    {
        public CloakCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<Cloak>()) { }
    }
}