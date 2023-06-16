namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfCestiGlovesArmourItem : GlovesArmorItem
    {
        public SetOfCestiGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CestiGlovesArmorItemFactory>()) { }
    }
}