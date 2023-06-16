namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfGauntletsGlovesArmourItem : GlovesArmorItem
    {
        public SetOfGauntletsGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GauntletsGlovesArmorItemFactory>()) { }
    }
}