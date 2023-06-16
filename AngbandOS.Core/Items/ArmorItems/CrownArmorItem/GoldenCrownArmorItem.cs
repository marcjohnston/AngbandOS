namespace AngbandOS.Core.Items;

[Serializable]
internal class GoldenCrownArmorItem : CrownArmorItem
{
    public GoldenCrownArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldenCrownArmorItemFactory>()) { }
}