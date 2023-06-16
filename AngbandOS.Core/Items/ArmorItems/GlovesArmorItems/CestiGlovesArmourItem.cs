namespace AngbandOS.Core.Items;

[Serializable]
internal class CestiGlovesArmourItem : GlovesArmorItem
{
    public CestiGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CestiGlovesArmorItemFactory>()) { }
}