namespace AngbandOS.Core.Items;

[Serializable]
internal class ClothCloakCloakArmorItem : CloakArmorItem
{
    public ClothCloakCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ClothCloakCloakArmorItemFactory>()) { }
}