namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LeatherGlovesArmourItem : GlovesArmorItem
    {
        public LeatherGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LeatherGlovesArmorItemFactory>()) { }
    }
}