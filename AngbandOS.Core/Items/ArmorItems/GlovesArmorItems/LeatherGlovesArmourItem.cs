namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfLeatherGlovesArmourItem : GlovesArmorItem
    {
        public SetOfLeatherGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LeatherGlovesArmorItemFactory>()) { }
    }
}