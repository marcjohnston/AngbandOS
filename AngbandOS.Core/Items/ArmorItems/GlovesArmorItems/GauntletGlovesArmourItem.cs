namespace AngbandOS.Core.Items;

[Serializable]
internal class GauntletGlovesArmourItem : GlovesArmorItem
{
    public GauntletGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GauntletGlovesArmorItemFactory>()) { }
}