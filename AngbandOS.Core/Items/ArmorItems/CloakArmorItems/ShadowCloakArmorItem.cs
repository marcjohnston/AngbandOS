namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShadowCloakArmorItem : CloakArmorItem
    {
        public ShadowCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ShadowCloakArmorItemFactory>()) { }
    }
}