namespace AngbandOS.Core.Items;

[Serializable]
internal class IronCrownArmorItem : CrownArmorItem
{
    public IronCrownArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<IronCrownArmorItemFactory>()) { }
}